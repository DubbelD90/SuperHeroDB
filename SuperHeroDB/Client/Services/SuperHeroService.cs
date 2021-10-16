using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;

        public SuperHeroService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
        {
            var result = await _httpClient.PostAsJsonAsync($"/api/SuperHero", hero);
            var heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            return heroes;
        }

        public async Task GetComics()
        {
            Comics = await _httpClient.GetFromJsonAsync<List<Comic>>($"/api/superhero/comics");
        }

        public async Task<SuperHero> GetSuperHero(int id)
        {
            return await _httpClient.GetFromJsonAsync<SuperHero>($"/api/SuperHero/{id}");
        }

        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            return await _httpClient.GetFromJsonAsync<List<SuperHero>>("/api/SuperHero");
        }
    }
}
