namespace SIGOBackend.Domain.Entities
{
    public class UnidadResponsable
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid CampusId { get; set; } // Referencia al Campus
        public DateTime FechaRegistro { get; set; }
        public Guid RegistradoPor { get; set; } // Referencia al Usuario
        public List<Subestacion> Subestaciones { get; set; }
        public Facturas Facturas { get; set; }
    }

    public class Subestacion
    {
        public Guid Id { get; set; }
        public int NoServicio { get; set; }
        public string NoMedidor { get; set; }
        public string Tarifa { get; set; }
        public double Multiplicador { get; set; }
    }

    public class Facturas
    {
        public List<FacturaGDBT> GDBT { get; set; }
    }

    public class FacturaGDBT
    {
        public string Periodo { get; set; }
        public int DiasDelPeriodo { get; set; }
        public double Consumo { get; set; }
        public double DemandaMaxima { get; set; }
        public double FactorDePotencia { get; set; }
        public double FactorDeCarga { get; set; }
        public double CargoPorEnergia { get; set; }
        public double ImporteDemandaMaxima { get; set; }
        public double ImporteFP { get; set; }
        public double DAP { get; set; }
        public double IVA { get; set; }
        public double TotalAPagar { get; set; }
    }
}