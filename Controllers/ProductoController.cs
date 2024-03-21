using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sorteo.Application.Services;
using Sorteo.Domain.Interfaces;
using Sorteo.Domain.Models;

namespace Sorteo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        //private readonly IApiKeyRepository _apiKeyService;
        private readonly IProductoRepository _productoService;

        public ProductoController(IProductoRepository productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
        //[AuthorizeApiKey]
        public async Task<ActionResult<Producto>> CrearProducto([FromBody] Producto productoDto)
        {
            try
            {
                var producto = await _productoService.CreateAsync(productoDto);
                return Ok(producto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
