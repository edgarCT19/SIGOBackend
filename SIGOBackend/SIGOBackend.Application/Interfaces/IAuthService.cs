using SIGOBackend.Application.DTOs;

namespace SIGOBackend.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDTO> Login(LoginResponseDTO loginDto);
}