using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly StoreContext _context;

        public BeerController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerDto>>> Get()
        {
            return await _context.Beers
                .Select(b => new BeerDto
                {
                    Id = b.BeerId,
                    Name = b.Name,
                    BrandId = b.BrandId,
                    Alcohol = b.Alcohol
                })
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer is null)
            {
                return NotFound();
            }

            return new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                BrandId = beer.BrandId,
                Alcohol = beer.Alcohol
            };
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Create(BeerInsertDto input)
        {
            if (!await _context.Brands.AnyAsync(brand => brand.BrandId == input.BrandId))
            {
                return BadRequest($"Brand {input.BrandId} does not exist.");
            }

            var beer = new Beer
            {
                Name = input.Name,
                BrandId = input.BrandId,
                Alcohol = input.Alcohol
            };

            _context.Beers.Add(beer);
            await _context.SaveChangesAsync();

            var result = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                BrandId = beer.BrandId,
                Alcohol = beer.Alcohol
            };

            return CreatedAtAction(nameof(GetById), new { id = beer.BeerId }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, BeerUpdateDto input)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer is null)
            {
                return NotFound();
            }

            if (!await _context.Brands.AnyAsync(brand => brand.BrandId == input.BrandId))
            {
                return BadRequest($"Brand {input.BrandId} does not exist.");
            }

            beer.Name = input.Name;
            beer.BrandId = input.BrandId;
            beer.Alcohol = input.Alcohol;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            if (beer is null)
            {
                return NotFound();
            }

            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
