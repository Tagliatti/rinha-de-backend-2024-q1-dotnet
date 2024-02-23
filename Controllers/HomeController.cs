using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace RinhaBackend2024Q1.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet("/", Name = "HealthCheck")]
    public String Index()
    {
        return DateTime.UtcNow.ToString("O");
    }
}