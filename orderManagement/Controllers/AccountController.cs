using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Entities.Identity;
using orderManagement.Core.Interface;
using orderManagement.Dtos.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace orderManagement.Controllers
{
    public class AccountController : BaseController
    {
        #region initial the class
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        #endregion


        [HttpPost("role")]
        public async Task<ActionResult<RoleDto>> CreateRole(RoleDto roleDto)
        {
            //Detect the role name exist
            var roleGet = await _roleManager.FindByNameAsync(roleDto.Name);
            if (roleGet != null) return BadRequest("Role is exist");
            // create a new role
            var role = new AppRole()
            {
                Name = roleDto.Name,
                NormalizedName = roleDto.Name.ToUpper()
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded) 
            {
                return Ok(_mapper.Map<RoleDto>(role));
            }
            // result.error then return badrequest
            return BadRequest("Some thing wrong when create a role");
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);
            user.UserName = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Work");
            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDTO)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDTO.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded) return Unauthorized();

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = await _tokenService.CreateToken(user);
            return Ok(userDto);
        }

        // add a role to user
        // TODO: Add Authorize when deployment
        [HttpPut("role/{username}")]
        public async Task<ActionResult<UserDto>> AddRoleToUser(string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("Not find the user");
            // get current roles from the user
            var userRoles = await _userManager.GetRolesAsync(user);
            // add new role base on the current roles
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
            if (!result.Succeeded) return BadRequest("Failed to add to roles");
            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
            if (!result.Succeeded) return BadRequest("Failed to remove from the roles");
            return Ok(await _userManager.GetRolesAsync(user));
        }

        // get  user of the all role
        // TODO: Add Authorize when deployment
        // TODO: Add Pagination with return
        [HttpGet("usersroles")]
        public async Task<ActionResult> GetUserWithRole()
        {
            var users = await _userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()

                })
                .ToListAsync();
            return Ok(users);
        }


        #region private method


        /// <summary>
        /// Used to detect the existence of a database based on the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
        #endregion
    }
}
