using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SIGOBackend.Domain.Entities
{
    // CATALOGO INCIAL Y REGISTRO EXTRA
    public class UnidadResponsable
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid CampusId { get; set; } // Referencia al Campus
        public DateTime FechaRegistro { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid RegistradoPor { get; set; } // Referencia al Usuario NO ES NECEESARIO
        public List<Subestacion> Subestaciones { get; set; }
        public Facturas Facturas { get; set; }
        public InventarioEnergético InventarioEnergético { get; set; }
    }

    public class Subestacion
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public int NoServicio { get; set; }
        public string NoMedidor { get; set; }
        public string Tarifa { get; set; }
        public double Multiplicador { get; set; }
    }

    public class Facturas
    {
        public List<FacturaGDBT> GDBT { get; set; }
        public List<FacturaPDBT> PDBT { get; set; }
        public List<FacturaMT> GDMTHyGDMTO { get; set; }
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
        public string ArchivoURL { get; set; }
        public double TotalAPagar { get; set; }
    }

    public class FacturaPDBT
    {
        public string Periodo { get; set; }
        public int DiasDelPeriodo { get; set; }
        public double Consumo { get; set; }
        public double CargoPorEnergia { get; set; }
        public double ImporteDemandaMaxima { get; set; }
        public double DAP { get; set; }
        public double IVA { get; set; }
        public string ArchivoURL { get; set; }
        public double TotalAPagar { get; set; }
    }

    public class FacturaMT
    {
        public string Periodo { get; set; }
        public int DiasDelPeriodo { get; set; }
        public double Consumo { get; set; }
        public double DemandaMaxima { get; set; }
        public double FactorDePotencia { get; set; }
        public double FactorDeCarga { get; set; }
        public double CargoPorEnergia { get; set; }
        public double ImporteDemandaMaxima { get; set; }
        public double ImporteMedicionBT { get; set; }
        public double ImporteFP { get; set; }
        public double DAP { get; set; }
        public double IVA { get; set; }
        public string ArchivoURL { get; set; }
        public string TipoDeFactura { get; set; }
        public double TotalAPagar { get; set; }
        public List<Subestacion> Subestaciones { get; set; } // Relación con subestaciones
    }

    // Nueva clase para Inventarios Energéticos
    public class InventarioEnergético
    {
        public List<AireAcondicionado> AA { get; set; }
        public List<Miscelaneo> Miscelaneos { get; set; }
        public List<Luminaria> Luminarias { get; set; }
    }

    // Equipos de Aire Acondicionado
    public class AireAcondicionado
    {
        public string TipoDeAA { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Capacidad { get; set; }
        public double Voltaje { get; set; }
        public double Amperaje { get; set; }
        public double Potencia { get; set; }
        public double PotenciaTotal { get; set; }
        public double TotalDeHorasDeUsoAlMes { get; set; }
        public double ConsumoMensual { get; set; }
    }

    // Equipos Misceláneos
    public class Miscelaneo
    {
        public string TipoDeMiscelaneo { get; set; }
        public string Modelo { get; set; }
        public double Voltaje { get; set; }
        public double Amperaje { get; set; }
        public double Potencia { get; set; }
        public double PotenciaTotal { get; set; }
        public double TotalDeHorasDeUsoAlMes { get; set; }
        public double ConsumoMensual { get; set; }
    }

    // Equipos Luminarias
    public class Luminaria
    {
        public string TipoDeLampara { get; set; }
        public int NumeroDeLuminarias { get; set; }
        public double LumenesPorLuminaria { get; set; }
        public double PotenciaPorLuminaria { get; set; }
        public double PotenciaTotalDelConjunto { get; set; }
        public double TotalDeHorasDeUsoAlMes { get; set; }
        public double ConsumoMensual { get; set; }
    }
}