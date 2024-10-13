using Microsoft.AspNetCore.Mvc;
using SE_Project.Data;
using SE_Project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SE_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public List<Movie> Get()
        {
            var MovieList = _context.Movies.Select(x => new Movie
            {
                MovieID = x.MovieID,
                MovieName = x.MovieName,
                Genre = x.Genre,
                MovieDuration = x.MovieDuration,
                MovieTime = x.MovieTime,
            });
            return MovieList.ToList();
        }

        // POST api/<MoviesController>
        // New Movie
        [HttpPost("{ID}, {Name}, {Genre}, {Duration}, {Time}")]
        public async Task<ActionResult> PostAsync(string ID, string Name, string Genre, int Duration, DateTime Time)
        {
            if(_context.Movies.Any(x =>  x.MovieID == ID))
            {
                return BadRequest("Movie ID must be unique");
            }

            var newMovie = new Movie
            {
                MovieID = ID,
                MovieName = Name,
                Genre = Genre,
                MovieDuration = Duration,
                MovieTime = Time
            };

            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();
            return Ok(newMovie);
        }

        // DELETE api/<MoviesController>/5
        // Delete Movie
        [HttpDelete("{MovieID}")]
        public async Task<ActionResult> DeleteAsync(string MovieID)
        {
            var delMovie = _context.Movies.FirstOrDefault(x => x.MovieID == MovieID);

            if (delMovie == null)
            {
                return NotFound("MovieID is Invalid");
            }

            _context.Movies.Remove(delMovie);
            await _context.SaveChangesAsync();

            return Ok(delMovie);
        }
    }
}
