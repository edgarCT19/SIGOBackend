using Microsoft.AspNetCore.Mvc;
using SIGOBackend.Application.Services;
using SIGOBackend.Domain.Entities;
using SIGOBackend.Application.DTOs;

namespace SIGOBackend.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO credenciales)
        {
            var user = await _usuarioService.AuthenticateAsync(credenciales);
            if (user == null) return Unauthorized();
            return Ok(new { Token = "generar_jwt_aquí" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO usuario)
        {
            await _usuarioService.AddUsuarioAsync(usuario);
            return Ok();
        }
    }
}