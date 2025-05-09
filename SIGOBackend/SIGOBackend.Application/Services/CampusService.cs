using SIGOBackend.Application.DTOs;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Application.Interfaces.IServices;
using SIGOBackend.Domain.Entities;

namespace SIGOBackend.Application.Services;

public class CampusService : ICampusService
{
    private readonly ICampusRepository _campusRepository;

    public CampusService(ICampusRepository campusRepository)
    {
        _campusRepository = campusRepository;
    }
    // PUEDE SER INECESARIO AL SER UNA LISTA Y TENER POCOS DATOS
    public async Task<Campus> GetByIdAsync(Guid id)
    {
        return await _campusRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Campus>> GetAllAsync()
    {
        return await _campusRepository.GetAllAsync();
    }

    public async Task<Guid> AddAsync(AddCampusDTO campus)
    {
        if (string.IsNullOrEmpty(campus.Nombre) || string.IsNullOrEmpty(campus.Ubicacion))
        {
            throw new ArgumentException("Nombre and Ubicacion are required.");
        }
        Guid NewGuid;
        NewGuid = Guid.NewGuid();
        var newCampus = new Campus
        {
            Id = NewGuid,
            Nombre = campus.Nombre,
            Ubicacion = campus.Ubicacion,
            FechaRegistro = DateTime.UtcNow
        };
        await _campusRepository.AddAsync(newCampus);
        return NewGuid;
    }

    public async Task UpdateAsync(UpdateCampusDTO campus)
    {
        var existingCampus = await _campusRepository.GetByIdAsync(campus.Id);
        if (existingCampus == null)
        {
            throw new KeyNotFoundException("Campus no encontrado.");
        }
        if (string.IsNullOrEmpty(campus.Nombre) || string.IsNullOrEmpty(campus.Ubicacion))
        {
            throw new ArgumentException("Nombre y Ubicacion son requeridos.");
        }
        // Update other properties as needed
        existingCampus.Nombre = campus.Nombre;
        existingCampus.Ubicacion = campus.Ubicacion;
        await _campusRepository.UpdateAsync(existingCampus);
    }

    public async Task DeleteAsync(Guid id)
    {
        var campus = await _campusRepository.GetByIdAsync(id);
        if (campus == null)
        {
            throw new KeyNotFoundException("Campus not found.");
        }

        await _campusRepository.DeleteAsync(id);
    }
}