using MongoDB.Driver;
using SIGOBackend.Domain.Entities;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Infrastructure.Data;

namespace SIGOBackend.Application.Repositories
{
    public class SubestacionRepository : ISubestacionRepository
    {
        private readonly IMongoCollection<Subestacion> _subestaciones;

        public SubestacionRepository(MongoDbContext context)
        {
            _subestaciones = context.Subestaciones;
        }

        public async Task<Subestacion> GetByIdAsync(Guid id)
        {
            return await _subestaciones.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Subestacion>> GetAllAsync()
        {
            return await _subestaciones.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(Subestacion subestacion)
        {
            await _subestaciones.InsertOneAsync(subestacion);
        }

        public async Task UpdateAsync(Subestacion subestacion)
        {
            await _subestaciones.ReplaceOneAsync(s => s.Id == subestacion.Id, subestacion);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _subestaciones.DeleteOneAsync(s => s.Id == id);
        }
    }
}