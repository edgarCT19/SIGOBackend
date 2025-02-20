using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGOBackend.Infrastructure.Data;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Application.Services;
using SIGOBackend.Application.Repositories;

namespace SIGOBackend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
            var databaseName = configuration.GetSection("MongoDB:DatabaseName").Value;

            services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(connectionString, databaseName));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<UsuarioService>();

            // Registra otros servicios de la capa de aplicación aquí
            // services.AddTransient<IMiServicio, MiServicio>();

            return services;
        }
    }
}