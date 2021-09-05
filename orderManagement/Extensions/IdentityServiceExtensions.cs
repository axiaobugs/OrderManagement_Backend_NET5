using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using orderManagement.Core.Entities.Identity;
using orderManagement.Infrastructure.Data;
using System.Text;

namespace orderManagement.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection service, IConfiguration config)
        {
            service.AddIdentityCore<AppUser>(opt=> {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<StoreDbContext>();

            service.AddAuthentication(op=> {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(op =>
                {

                    // NOTE: Remember to modify the parameters that need to be verified during actual production
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateActor=false
                    };
                });

            // NOTE: Modify the appropriate permission policy when it is actually applied
            service.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminRole", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("WorkerRole", policy => policy.RequireRole("Worker"));
                // GeneralViewMode counld't check like employee salary or order price etc Sensitive Information
                opt.AddPolicy("GeneralViewMode", policy => policy.RequireRole("Worker,Admin,Engineering,Sale,Office"));
                // DetailViewMode could check all of the Sensitive Information
                opt.AddPolicy("DetailViewMode", policy => policy.RequireRole("Engineering"));
                opt.AddPolicy("EditMode", policy => policy.RequireRole("Admin,Engineering,Sale"));
            });


            return service;
        }
    }
}
