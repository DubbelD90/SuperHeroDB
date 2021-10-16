using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        static List<Comic> comics = new List<Comic>
        {
            new Comic {Name = "Marvel"},
            new Comic {Name = "DC Universe"}
        };

        List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero {Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", Comic = comics[0]},
            new SuperHero {Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", Comic = comics[1]}
        };

        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            return Ok(comics);
        }

        [HttpGet]
        public async Task<IActionResult> GetSuperHeroes()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleSuperHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
                return NotFound("Hero was not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero(SuperHero hero)
        {
            heroes.Add(hero);

            return Ok(heroes);
        }
    }
}
