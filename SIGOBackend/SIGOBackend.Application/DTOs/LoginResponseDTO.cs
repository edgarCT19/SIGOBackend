namespace SIGOBackend.Application.DTOs;

public class LoginResponseDTO
{
    public Guid UserId { get; set; } // ID del usuario
    public string Token { get; set; } // Token de autenticación
}