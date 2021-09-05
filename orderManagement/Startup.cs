using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using orderManagement.Extensions;
using orderManagement.Helpers;
using orderManagement.Infrastructure.Data;

namespace orderManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<StoreDbContext>(x =>
                x.UseSqlServer(Configuration["ConnectionStrings:StoreConnection"]));
            services.AddApplicationServices();
            services.AddIdentityServices(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Management", Version = "v1" });
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    // Parameters added to the header
                    In = ParameterLocation.Header,
                    // Use Authorize header
                    Type = SecuritySchemeType.Http,
                    // Content starts with bearer
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                };

                // Configure all methods to add bearer headers
                var securityRequirement = new OpenApiSecurityRequirement
                    {
                        {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "bearerAuth"
                                    }
                                },
                                new string[] {}
                        }
                    };

                // Register to swagger
                c.AddSecurityDefinition("bearerAuth", securityScheme);
                c.AddSecurityRequirement(securityRequirement);
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "orderManagement v1"));
            }
            
            app.UseRouting();
            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200"));
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
