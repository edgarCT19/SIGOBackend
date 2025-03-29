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
        // CONTEXTO DE CONFIGURACION DEL SISTEMA
        public IMongoCollection<ConfiguracionSistema> ConfiguracionSistema => _database.GetCollection<ConfiguracionSistema>("ConfiguracionSistema");
        public IMongoCollection<Logos> Logos => _database.GetCollection<Logos>("Logos");
        public IMongoCollection<Tema> Tema => _database.GetCollection<Tema>("Tema");
        public IMongoCollection<Colores> Colores => _database.GetCollection<Colores>("Colores");
        public IMongoCollection<Tipografia> Tipografia => _database.GetCollection<Tipografia>("Tipografia");
        // CONTEXTO DEL SISTEMA EN SI
        public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("Usuarios");
        public IMongoCollection<Campus> Campus => _database.GetCollection<Campus>("Campus");
        public IMongoCollection<UnidadResponsable> UnidadesResponsables => _database.GetCollection<UnidadResponsable>("UnidadesResponsables");
        public IMongoCollection<ConfiguracionSistema> Configuracion => _database.GetCollection<ConfiguracionSistema>("Configuracion");
        public IMongoCollection<Subestacion> Subestaciones => _database.GetCollection<Subestacion>("Subestaciones");
        public IMongoCollection<Area> Areas => _database.GetCollection<Area>("Areas");
        public IMongoCollection<Edificio> Edificios => _database.GetCollection<Edificio>("Edificios");
        public IMongoCollection<InventarioEnergético> InventariosEnergéticos => _database.GetCollection<InventarioEnergético>("InventariosEnergéticos");
        public IMongoCollection<FacturaGDBT> FacturasGDBT => _database.GetCollection<FacturaGDBT>("FacturasGDBT");
        public IMongoCollection<FacturaPDBT> FacturasPDBT => _database.GetCollection<FacturaPDBT>("FacturasPDBT");
        public IMongoCollection<FacturaMT> FacturasMT => _database.GetCollection<FacturaMT>("FacturasMT");
        public IMongoCollection<Facturas> Facturas => _database.GetCollection<Facturas>("FacturasGDMTHyGDMTO");
        public IMongoCollection<Miscelaneo> Miscelaneo => _database.GetCollection<Miscelaneo>("ConfiguracionSistema");
        public IMongoCollection<Luminaria> Luminaria => _database.GetCollection<Luminaria>("ConfiguracionSistema");
        
    }
}