using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public interface ISuperHeroService
    {
        List<Comic> Comics { get; set; }
        Task<List<SuperHero>> GetSuperHeroes();
        Task GetComics();
        Task<SuperHero> GetSuperHero(int id);
        Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
    }
}
