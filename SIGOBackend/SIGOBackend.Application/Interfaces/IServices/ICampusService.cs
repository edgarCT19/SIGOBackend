using SIGOBackend.Application.DTOs;
using SIGOBackend.Domain.Entities;


namespace SIGOBackend.Application.Interfaces.IServices
{
    public interface ICampusService
    {
        Task<Campus> GetByIdAsync(Guid id);
        Task<IEnumerable<Campus>> GetAllAsync();
        Task<Guid> AddAsync(AddCampusDTO campus);
        Task UpdateAsync(UpdateCampusDTO campus);
        Task DeleteAsync(Guid id);
    }
}