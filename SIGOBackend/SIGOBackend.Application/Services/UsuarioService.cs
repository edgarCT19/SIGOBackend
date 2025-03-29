// SIGOBackend.Application/Services/UsuarioService.cs
using SIGOBackend.Application.DTOs;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Domain.Entities;
using System.Threading.Tasks;

namespace SIGOBackend.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService; // Si decides usar un servicio de token para generar JWT

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService; // Si decides usar un servicio de token para generar JWT
        }

        public async Task<LoginResponseDTO> AuthenticateAsync(LoginDTO credenciales)
        {
            var user = await _usuarioRepository.GetByUsuarioAsync(credenciales.Correo);
            if (user == null || user.Password != credenciales.Password) // Aquí deberías usar un hash para comparar contraseñas
                return null;
            var token = _tokenService.GenerateToken(user);

            return new LoginResponseDTO
            {
                UserId = user.Id,
                Token = token,
            };
        }

        public async Task AddUsuarioAsync(RegisterUserDTO usuario)
        {
            Guid userGuid;
            Usuario existingUser;
            do
            {
                userGuid = Guid.NewGuid();
                existingUser = await _usuarioRepository.GetByIdAsync(userGuid);
            } while (existingUser != null);
            await _usuarioRepository.AddAsync(new Usuario
            {
                Id = userGuid,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                NombreDeUsuario = usuario.NombreDeUsuario,
                Password = usuario.Password // Aquí deberías usar un hash para guardar contraseñas
            });
        }

        public async Task<List<Usuario>?> GetUsuarios()
        {
            var user = await _usuarioRepository.GetAllAsync();
            if (user == null) return null;
            return [.. user];
        }

        // Implementa otros métodos según sea necesario
    }
}