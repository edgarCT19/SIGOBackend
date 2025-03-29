namespace SIGOBackend.Application.DTOs;

public class SubestacionDTO
{
    public Guid Id { get; set; }
    public int NoServicio { get; set; }
    public string NoMedidor { get; set; }
    public string Tarifa { get; set; }
    public double Multiplicador { get; set; }
}

public class AddSubestacionDTO
{
    public int NoServicio { get; set; }
    public string NoMedidor { get; set; }
    public string Tarifa { get; set; }
    public double Multiplicador { get; set; }
}