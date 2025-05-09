using SIGOBackend.Domain.Entities;

namespace SIGOBackend.Application.Interfaces
{   
    public interface ISubestacionRepository
    {
        Task<Subestacion> GetByIdAsync(Guid id);
        Task<IEnumerable<Subestacion>> GetAllAsync();
        Task AddAsync(Subestacion subestacion);
        Task UpdateAsync(Subestacion subestacion);
        Task DeleteAsync(Guid id);
    }
}