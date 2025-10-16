using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using backendRickandMorty.Models;

namespace backendRickandMorty.Services
{
    public class RickAndMortyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://rickandmortyapi.com/api";

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Characters
        public async Task<List<Character>> GetAllCharactersAsync()
        {
            var url = $"{_baseUrl}/character";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al obtener personajes");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var characterResponse = JsonSerializer.Deserialize<CharacterResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return characterResponse.Results;
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            var url = $"{_baseUrl}/character/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error al obtener personaje con id {id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Character>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Locations
        public async Task<List<Location>> GetAllLocationsAsync()
        {
            var url = $"{_baseUrl}/location";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al obtener locations");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var locationResponse = JsonSerializer.Deserialize<LocationResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return locationResponse.Results;
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            var url = $"{_baseUrl}/location/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error al obtener location con id {id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Location>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Episodes
        public async Task<List<Episode>> GetAllEpisodesAsync()
        {
            var url = $"{_baseUrl}/episode";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al obtener episodes");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var episodeResponse = JsonSerializer.Deserialize<EpisodeResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return episodeResponse.Results;
        }

        public async Task<Episode> GetEpisodeByIdAsync(int id)
        {
            var url = $"{_baseUrl}/episode/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error al obtener episode con id {id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Episode>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }

    // Clases para deserializar las respuestas con listas y resultados
    public class CharacterResponse
    {
        public List<Character> Results { get; set; }
    }

    public class LocationResponse
    {
        public List<Location> Results { get; set; }
    }

    public class EpisodeResponse
    {
        public List<Episode> Results { get; set; }
    }
}
