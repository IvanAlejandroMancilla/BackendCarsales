using Microsoft.AspNetCore.Mvc;

namespace backendRickandMorty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        #region lista de todas locations
        [HttpGet]
        public IActionResult ListaLocations()
        {
            Console.WriteLine("Ejecutando ListaLocations");
            // Respuesta de ejemplo
            return Ok(new { Mensaje = "Lista de todas las locations", Locations = new List<string> { "Location 1", "Location 2" } });
        }
        #endregion

        #region lista de single locations
        [HttpGet("{id}")]
        public IActionResult ObtenerLocation(int id)
        {
            Console.WriteLine($"Obteniendo location con id {id}");
            // Respuesta de ejemplo
            return Ok(new { Mensaje = $"Detalles de la location {id}", Id = id });
        }
        #endregion

        #region lista de multiples locations
        [HttpGet("multiples/{ids}")]
        public IActionResult ObtenerMultiplesLocations(string ids)
        {
            Console.WriteLine($"Obteniendo múltiples locations con ids {ids}");
            // Respuesta de ejemplo
            var idsArray = ids.Split(',').Select(int.Parse).ToList();
            return Ok(new { Mensaje = $"Detalles de locations con ids: {ids}", Ids = idsArray });
        }
        #endregion
    }
}
