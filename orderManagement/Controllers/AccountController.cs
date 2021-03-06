using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Entities.Identity;
using orderManagement.Core.Interface;
using orderManagement.Core.Specifications;
using orderManagement.Dtos.Identity;
using orderManagement.Extensions;
using System;
using System.Collections.Generic;
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
        

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);
            user.UserName = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Worker");
            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                EmployeeId = user.EmployeeId,
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

            var roles = await _userManager.GetRolesAsync(user);
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Roles = roles;
            userDto.Token = await _tokenService.CreateToken(user);
            return Ok(userDto);
        }

        //[Authorize(Policy = "AdminRole")]
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

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailFromClaimPrinciple(User);
            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Email = user.Email,
                EmployeeId = user.EmployeeId,
                Roles = await _userManager.GetRolesAsync(user)

            };
        }

        /// <summary>
        /// Check username or email exist when register
        /// </summary>
        /// <returns></returns>
        [HttpGet("exist")]
        public async Task<bool> CheckExist([FromQuery] string email = "",
                                            [FromQuery] string userName = "")
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrWhiteSpace(email))
            {
                return await _userManager.FindByEmailAsync(email) != null;
            }
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrWhiteSpace(userName))
            {
                return await _userManager.FindByNameAsync(userName) != null;
            }
            return false;

        }

        #region CURD Role API
        /// <summary>
        /// Get all role
        /// </summary>
        /// <returns></returns>
        [HttpGet("role")]
        public async Task<ActionResult<ICollection<string>>> GetAllRole ()
        {
            return await _roleManager.Roles.Select(x=>x.Name).ToListAsync();
        }

        /// <summary>
        /// Create a Role
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("role")]
        public async Task<ActionResult<RoleDto>> CreateRole(RoleDto roleDto)
        {
            Console.WriteLine(roleDto.Name);
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
        /// <summary>
        /// Delete a Role by query 
        /// </summary>
        /// <returns></returns>
        [HttpDelete("role")]
        public async Task<ActionResult> DeleteRoleByName(string roleName)
        {
            var roleFetch = await _roleManager.FindByNameAsync(roleName);
            if (roleFetch == null) return BadRequest("Can't found " + roleName + " role name in our database");
            var result = await _roleManager.DeleteAsync(roleFetch);
            return Ok(result);
        }

        #endregion

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
