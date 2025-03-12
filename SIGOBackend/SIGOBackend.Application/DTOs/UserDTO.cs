namespace SIGOBackend.Application.DTOs
{
    public class RegisterUserDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Password { get; set; }
    }
}