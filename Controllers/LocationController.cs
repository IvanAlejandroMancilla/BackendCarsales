using backendRickandMorty.Models;
using backendRickandMorty.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendRickandMorty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyService;

        public LocationController(RickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        // GET /location
        [HttpGet]
        public async Task<IActionResult> ListaLocations()
        {
            var locations = await _rickAndMortyService.GetAllLocationsAsync();
            return Ok(locations);
        }

        // GET /location/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerLocation(int id)
        {
            var location = await _rickAndMortyService.GetLocationByIdAsync(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        // GET /location/multiples/1,2,3
        [HttpGet("multiples/{ids}")]
        public async Task<IActionResult> ObtenerMultiplesLocations(string ids)
        {
            var idsArray = ids.Split(',').Select(idStr => int.TryParse(idStr, out int id) ? id : (int?)null)
                                           .Where(id => id.HasValue)
                                           .Select(id => id.Value)
                                           .ToList();

            var locations = new List<Location>();
            foreach (var id in idsArray)
            {
                var location = await _rickAndMortyService.GetLocationByIdAsync(id);
                if (location != null)
                    locations.Add(location);
            }

            return Ok(locations);
        }
    }
}
