using SIGOBackend.Application.DTOs;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Domain.Entities;

public class SubestacionService
{
    private readonly ISubestacionRepository _subestacionRepository;

    public SubestacionService(ISubestacionRepository subestacionRepository)
    {
        _subestacionRepository = subestacionRepository;
    }

    public async Task<SubestacionDTO> GetSubestacionById(Guid id)
    {
        var subestacion = await _subestacionRepository.GetByIdAsync(id);
        if (subestacion == null) return null;

        return new SubestacionDTO
        {
            Id = subestacion.Id,
            NoServicio = subestacion.NoServicio,
            NoMedidor = subestacion.NoMedidor,
            Tarifa = subestacion.Tarifa,
            Multiplicador = subestacion.Multiplicador,
        };
    }
    
    public async Task<IEnumerable<SubestacionDTO>> GetAllSubestaciones()
    {
        var subestaciones = await _subestacionRepository.GetAllAsync();
        return subestaciones.Select(s => new SubestacionDTO
        {
            Id = s.Id,
            NoServicio = s.NoServicio,
            NoMedidor = s.NoMedidor,
            Tarifa = s.Tarifa,
            Multiplicador = s.Multiplicador,
        });
    }

    public async Task AddSubestacion(AddSubestacionDTO addSubestacionDto)
    {
        var subestacion = new Subestacion
        {
            Id = Guid.NewGuid(), // asegurar que sea unica
            NoServicio = addSubestacionDto.NoServicio,
            NoMedidor = addSubestacionDto.NoMedidor,
            Tarifa = addSubestacionDto.Tarifa,
            Multiplicador = addSubestacionDto.Multiplicador,
        };
        await _subestacionRepository.AddAsync(subestacion);
    }

}