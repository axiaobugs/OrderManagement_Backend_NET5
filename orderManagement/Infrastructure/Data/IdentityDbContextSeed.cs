using Microsoft.AspNetCore.Identity;
using orderManagement.Core.Entities.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace orderManagement.Infrastructure.Data
{
    public class IdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "111@test.com",
                    UserName = "111@test.com",
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }
    }
}
