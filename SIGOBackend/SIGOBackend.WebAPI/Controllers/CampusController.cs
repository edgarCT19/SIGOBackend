using Microsoft.AspNetCore.Mvc;
using SIGOBackend.Application.DTOs;
using SIGOBackend.Application.Interfaces.IServices;
using SIGOBackend.Domain.Entities;

namespace SIGOBackend.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CampusController : ControllerBase
{
    private readonly ICampusService _campusService;

    public CampusController(ICampusService campusService)
    {
        _campusService = campusService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var campus = await _campusService.GetByIdAsync(id);
            if (campus == null)
            {
                return NotFound("Campus not found.");
            }
            return Ok(campus);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var campuses = await _campusService.GetAllAsync();
            return Ok(campuses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCampusDTO campusDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _campusService.AddAsync(campusDto);
            return CreatedAtAction(nameof(GetById), new { id = id }, new { id });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCampusDTO campusDto)
    {
        try
        {
            if (id != campusDto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _campusService.UpdateAsync(campusDto);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _campusService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}