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
    public class CharacterController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyService;

        public CharacterController(RickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        // GET /character
        [HttpGet]
        public async Task<IActionResult> ListaCharacters()
        {
            var characters = await _rickAndMortyService.GetAllCharactersAsync();
            return Ok(characters);
        }

        // GET /character/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCharacter(int id)
        {
            var character = await _rickAndMortyService.GetCharacterByIdAsync(id);
            if (character == null)
                return NotFound();

            return Ok(character);
        }

        // GET /character/multiples/{ids}
        [HttpGet("multiples/{ids}")]
        public async Task<IActionResult> ObtenerMultiplesCharacters(string ids)
        {
            var idsArray = ids.Split(',')
                .Select(idStr => int.TryParse(idStr, out int id) ? id : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            var characters = new List<Character>();

            foreach (var id in idsArray)
            {
                var character = await _rickAndMortyService.GetCharacterByIdAsync(id);
                if (character != null)
                    characters.Add(character);
            }

            return Ok(characters);
        }
    }
}
