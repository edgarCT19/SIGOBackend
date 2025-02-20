// SIGOBackend.Application/Services/UsuarioService.cs
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Domain.Entities;
using System.Threading.Tasks;

namespace SIGOBackend.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AuthenticateAsync(string usuario, string password)
        {
            var user = await _usuarioRepository.GetByUsuarioAsync(usuario);
            if (user == null || user.Password != password) // Aquí deberías usar un hash para comparar contraseñas
                return null;
            return user;
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        // Implementa otros métodos según sea necesario
    }
}