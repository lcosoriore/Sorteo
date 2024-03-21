using Microsoft.AspNetCore.Mvc;
using Sorteo.Application.Services;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;

namespace Sorteo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionController : ControllerBase
    {
       // private readonly IApiKeyRepository _apiKeyService;
        private readonly AsignacionService _asignacionService;

        public AsignacionController(AsignacionService asignacionService)
        {
            //_apiKeyService = apiKeyService;
            _asignacionService = asignacionService;
        }

        [HttpPost]
        //[AuthorizeApiKey]
        public async Task<ActionResult<Asignacion>> AsignarNumero([FromBody] AsignacionDto asignacionDto)
        {
            try
            {
                var asignacion = await _asignacionService.AsignarNumeroAsync(asignacionDto.ClienteId);
                return Ok(asignacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }

    public class AsignacionDto
    {
        public int Numero { get; set; }
        public int ClienteId { get; set; }
    }
}
