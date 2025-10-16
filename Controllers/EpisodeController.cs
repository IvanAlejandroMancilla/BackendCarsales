using Microsoft.AspNetCore.Mvc;
using backendRickandMorty.Services;
using backendRickandMorty.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendRickandMorty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpisodeController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyService;

        public EpisodeController(RickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        // GET /episode
        [HttpGet]
        public async Task<IActionResult> ListaEpisodes()
        {
            var episodes = await _rickAndMortyService.GetAllEpisodesAsync();
            return Ok(episodes);
        }

        // GET /episode/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerEpisode(int id)
        {
            var episode = await _rickAndMortyService.GetEpisodeByIdAsync(id);
            if (episode == null)
                return NotFound();

            return Ok(episode);
        }

        // GET /episode/multiples/{ids}
        [HttpGet("multiples/{ids}")]
        public async Task<IActionResult> ObtenerMultiplesEpisodes(string ids)
        {
            var idsArray = ids.Split(',')
                .Select(idStr => int.TryParse(idStr, out int id) ? id : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            var episodes = new List<Episode>();

            foreach (var id in idsArray)
            {
                var episode = await _rickAndMortyService.GetEpisodeByIdAsync(id);
                if (episode != null)
                    episodes.Add(episode);
            }

            return Ok(episodes);
        }
    }
}
