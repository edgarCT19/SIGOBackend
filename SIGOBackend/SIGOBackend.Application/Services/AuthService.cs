using SIGOBackend.Application.DTOs;
using SIGOBackend.Application.Interfaces;

namespace SIGOBackend.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<LoginResponseDTO> Login(LoginResponseDTO loginDto)
    {

        return await Task.FromResult(new LoginResponseDTO());
    }
}