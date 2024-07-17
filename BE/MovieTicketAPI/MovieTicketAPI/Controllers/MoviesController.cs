using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketAPI.Data;
using MovieTicketAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                ImageUrl = m.ImageUrl
            }).ToListAsync();
        }

        // GET: api/Movies/Details/5
        [HttpGet("Details/{id}")]
        public async Task<ActionResult<MovieDetails>> GetMovieDetails(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            // Mock data for MovieDetails
            var movieDetails = new MovieDetails
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageUrl = movie.ImageUrl,
                Genre = "Hành Động, Hồi hộp, Phiêu Lưu",
                Description = "Lốc Xoáy Tử Thần là một bộ phim hành động hấp dẫn...",
                Duration = "123 phút",
                ReleaseDate = new DateTime(2024, 7, 12),
                Director = "Lee Isaac Chung",
                Language = "Tiếng Anh - Phụ đề Tiếng Việt",
                Actors = new List<string> { "Glen Powell", "Daisy Edgar-Jones", "Anthony Ramos", "Kiernan Shipka" },
                Rated = "T13 - PHIM ĐƯỢC PHỔ BIẾN ĐẾN NGƯỜI XEM TỪ ĐỦ 13 TUỔI TRỞ LÊN (13+)"
            };

            return movieDetails;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie([FromForm] Movie movie, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", imageFile.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                movie.ImageUrl = $"/images/{imageFile.FileName}";
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(movie.ImageUrl))
            {
                var filePath = Path.Combine("wwwroot", movie.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
