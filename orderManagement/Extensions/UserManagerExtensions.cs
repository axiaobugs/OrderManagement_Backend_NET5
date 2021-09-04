using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Entities.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace orderManagement.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<Core.Entities.Identity.AppUser> FindByUserByClaimPrincipleWithAddressAdync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
