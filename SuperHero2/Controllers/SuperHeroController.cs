using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHero2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context; 
        }
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id= 1,
                    Name ="Spider Man",
                    FirstName="Peter",
                    LastName="Parcker",
                    Place ="New York City"
                },
                    new SuperHero
                {
                        Id = 2,
                    Name ="Spider Man 2",
                    FirstName="Peter2",
                    LastName="Parcker2",
                    Place ="New York City 2"
                },
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            

            return Ok( await _context.SuperHeroes23.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {

            var hero = await _context.SuperHeroes23.FindAsync(id);

            if (hero == null) return BadRequest("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {

            _context.SuperHeroes23.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes23.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>>  UpdateHero(SuperHero req)
        {
            var DBhero =await _context.SuperHeroes23.FindAsync(req.Id);
            if (DBhero == null) 
                return BadRequest("Hero not found");

            DBhero.Name = req.Name;
            DBhero.LastName = req.LastName;
            DBhero.Place = req.Place;
            DBhero.FirstName = req.FirstName;
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes23.ToListAsync());

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {

            var DBhero = await _context.SuperHeroes23.FindAsync(id);

            if (DBhero == null) return BadRequest("Hero not found");

           _context.SuperHeroes23.Remove(DBhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes23.ToListAsync());
        }
    }
}
