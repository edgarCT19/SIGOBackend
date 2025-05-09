using SIGOBackend.Domain.Entities;

namespace SIGOBackend.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario user);
    }
}