using MongoDB.Driver;
using SIGOBackend.Domain.Entities;

namespace SIGOBackend.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Campus> Campus => _database.GetCollection<Campus>("Campus");
        public IMongoCollection<UnidadResponsable> UnidadesResponsables => _database.GetCollection<UnidadResponsable>("UnidadesResponsables");
        public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("Usuarios");
        public IMongoCollection<ConfiguracionSistema> Configuracion => _database.GetCollection<ConfiguracionSistema>("Configuracion");
    }
}