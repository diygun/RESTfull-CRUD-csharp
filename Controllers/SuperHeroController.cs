using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.Api;
using SuperHero.Api.Data;
using SuperHeros.Api.Entities;


namespace SuperHeros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // I could use a controller but for this quick project I won't.

        private readonly DataConext _context;

        public SuperHeroController(DataConext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroModel>>> GetAllHeros()
        {
            // var heroes = new List<SuperHeroModel>
            // {
            //     new SuperHeroModel
            //     {
            //         Id = 1,
            //         Name = "Spiderman",
            //         FirstName = "Peter",
            //         LastName = "Paker",
            //         Place = "New York City"               
            //     }
            // };


            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        // [HttpGet]
        // [Route("{id}")]

        // OR :

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHeroModel>> GetHero(int id)
        {
            var heroes = await _context.SuperHeroes.FindAsync(id);
            if (heroes is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHeroModel>> AddHero(CreateHeroDto request)
        {
            var newHero = new SuperHeroModel
            {
                Name = request.Name,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Place = request.Place
            };

            _context.SuperHeroes.Add(newHero);
            await _context.SaveChangesAsync();

            // This will send back the full data from the db because EF repopulates automatically newHero with Id and all other fields. 
            return Ok(newHero);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SuperHeroModel>> UpdateHero(int id, UpdateHeroDto request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero is null)
            {
                return NotFound();
            }

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(dbHero);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<SuperHeroModel>>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero is null)
            {
                return NotFound();
            }
            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }


    }
}
