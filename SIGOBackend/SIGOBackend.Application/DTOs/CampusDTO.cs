namespace SIGOBackend.Application.DTOs
{
    public class AddCampusDTO
    {
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
    }
    public class UpdateCampusDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
    }
}