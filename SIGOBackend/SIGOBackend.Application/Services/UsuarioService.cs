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

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginResponseDTO> AuthenticateAsync(LoginDTO credenciales)
        {
            var user = await _usuarioRepository.GetByUsuarioAsync(credenciales.Correo);
            if (user == null || user.Password != credenciales.Password) // Aquí deberías usar un hash para comparar contraseñas
                return null;

            return new LoginResponseDTO
            {
                UserId = user.Id,
                Token = "generar_jwt_aquí"
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

        // Implementa otros métodos según sea necesario
    }
}