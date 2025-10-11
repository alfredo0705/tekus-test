using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tekus.Application.Contracts.Identity;
using Tekus.Identity.Entities;
using Tekus.Identity.Services;

namespace Tekus.Identity.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                // Configuración de DbContext para Identity
                services.AddDbContext<TekusIdentityDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DBConnectionString"),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly("Tekus.Identity"); // Especifica el ensamblado de migraciones
                            sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        }));

                // Configuración de Identity con soporte para roles
                services.AddIdentityCore<AppUser>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireDigit = false;
                })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<TekusIdentityDbContext>()
                .AddDefaultTokenProviders();

                // Configuración de autenticación JWT
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                            ValidateIssuer = true,
                            ValidIssuer = configuration["JwtSettings:Issuer"],
                            ValidateAudience = true,
                            ValidAudience = configuration["JwtSettings:Audience"],
                            ValidateLifetime = true
                        };
                    });

                // Configuración de Autorización y Políticas de Roles
                services.AddAuthorization(opt =>
                {
                    opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                });

                // Inyección de dependencias personalizadas
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<ITokenService, TokenService>();

                return services;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
