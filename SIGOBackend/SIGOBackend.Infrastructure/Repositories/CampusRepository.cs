using MongoDB.Driver;
using SIGOBackend.Domain.Entities;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Infrastructure.Data;

namespace SIGOBackend.Application.Repositories
{
    public class CampusRepository : ICampusRepository
    {
        private readonly IMongoCollection<Campus> _campus;

        public CampusRepository(MongoDbContext context)
        {
            _campus = context.Campus;
        }

        public async Task<Campus> GetByIdAsync(Guid id)
        {
            return await _campus.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Campus>> GetAllAsync()
        {
            return await _campus.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(Campus campus)
        {
            await _campus.InsertOneAsync(campus);
        }

        public async Task UpdateAsync(Campus campus)
        {
            await _campus.ReplaceOneAsync(c => c.Id == campus.Id, campus);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _campus.DeleteOneAsync(c => c.Id == id);
        }
    }
}