using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketAPI.Data;
using MovieTicketAPI.DTOs;
using MovieTicketAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Shows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetShows()
        {
            return await _context.Shows.Include(s => s.Movie).ToListAsync();
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var show = await _context.Shows.Include(s => s.Movie).FirstOrDefaultAsync(s => s.Id == id);

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        // PUT: api/Shows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (id != show.Id)
            {
                return BadRequest();
            }

            _context.Entry(show).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Shows
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(ShowCreateDto showDto)
        {
            var movie = await _context.Movies.FindAsync(showDto.MovieId);
            if (movie == null)
            {
                return BadRequest("Invalid MovieId.");
            }

            var show = new Show
            {
                StartTime = showDto.StartTime,
                EndTime = showDto.EndTime,
                MovieId = showDto.MovieId,
                Movie = movie
            };

            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShow), new { id = show.Id }, show);
        }

        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
