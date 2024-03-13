using Microsoft.AspNetCore.Mvc;

namespace Blog2.Controllers
{
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}


//Health check ou checagem de saúde 
//Serve para verificar se a API está online 



















