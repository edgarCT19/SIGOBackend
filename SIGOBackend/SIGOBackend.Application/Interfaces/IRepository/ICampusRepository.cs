using SIGOBackend.Domain.Entities;

namespace SIGOBackend.Application.Interfaces
{
    public interface ICampusRepository
    {
        Task<Campus> GetByIdAsync(Guid id);
        Task<IEnumerable<Campus>> GetAllAsync();
        Task AddAsync(Campus campus);
        Task UpdateAsync(Campus campus);
        Task DeleteAsync(Guid id);
    }
}