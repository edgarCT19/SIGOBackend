namespace SIGOBackend.Application.DTOs;

public class LoginResponseDTO
{
    public int UserId { get; set; } // ID del usuario
    public string Token { get; set; } // Token de autenticación
}