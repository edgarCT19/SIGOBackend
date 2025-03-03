namespace SIGOBackend.Domain.Entities
{
    public class Edificio
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Guid ResponsableAlta { get; set; } // Usuario que realizó el registro
    }
}