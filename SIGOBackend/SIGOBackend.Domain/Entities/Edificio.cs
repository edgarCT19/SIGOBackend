namespace SIGOBackend.Domain.Entities
{
    // Unidad Responsable
    // CATALOGO INICIAL REQUERIDO
    public class Edificio
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; } // NO ES NECESARIO
        public Guid ResponsableAlta { get; set; } // NO ES NECESARIO
    }
}