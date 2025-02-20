namespace SIGOBackend.Domain.Entities
{
    public class Campus
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}