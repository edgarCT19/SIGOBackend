// SIGOBackend.Application/Interfaces/IUsuarioRepository.cs
using SIGOBackend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGOBackend.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(Guid id);
        Task<Usuario> GetByUsuarioAsync(string Correo);
        Task<Usuario> GetByCorreoAsync(string correo);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);
    }
}