using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGOBackend.Infrastructure.Data;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Application.Services;
using SIGOBackend.Application.Repositories;
using SIGOBackend.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SIGOBackend.Application.Interfaces.IServices;

namespace SIGOBackend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
            var databaseName = configuration.GetSection("MongoDB:DatabaseName").Value;

            services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(connectionString, databaseName));
            // REPOSITORIOS
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ISubestacionRepository, SubestacionRepository>();
            services.AddScoped<ICampusRepository, CampusRepository>();
            // SERVICIOS
            services.AddScoped<UsuarioService>();
            services.AddScoped<ICampusService, CampusService>();
            // token
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddTransient<ITokenService ,TokenService>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            // Registra otros servicios de la capa de aplicación aquí
            // services.AddTransient<IMiServicio, MiServicio>();

            return services;
        }
    }
}