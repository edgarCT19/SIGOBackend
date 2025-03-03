namespace SIGOBackend.Domain.Entities
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid EdificioId { get; set; } // Relaci�n con Edificio
        public Guid UnidadResponsableId { get; set; } // Relaci�n con Unidad Responsable
        public string Encargado { get; set; }
        public string TelefonoEncargado { get; set; }
    }
}