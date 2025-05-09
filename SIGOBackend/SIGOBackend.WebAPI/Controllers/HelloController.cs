using Microsoft.AspNetCore.Mvc;

namespace SIGOBackend.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hola Mundo");
    }
}