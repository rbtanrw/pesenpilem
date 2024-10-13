using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE_Project.Data;
using SE_Project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SE_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TheatersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<TheatersController>
        [HttpGet]
        public List<Theater> Get()
        {
            var TheaterList = _context.Theaters.Select(x => new Theater
            {
                TheaterID = x.TheaterID,
                Capacity = x.Capacity,
                MovieID = x.MovieID,
            });
            return TheaterList.ToList();
        }

        // PUT api/<TheatersController>/5
        // Update Movie
        [HttpPut("{TheaterID}")]
        public async Task<ActionResult> PutAsync(string TheaterID, [FromBody] string MovieID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Theaters.Any(x => x.TheaterID == TheaterID))
            {
                return NotFound("Incorrect TheaterID");
            }

            var Theater = _context.Theaters.FirstOrDefault(x => x.TheaterID == TheaterID);
            if (Theater != null)
            {
                Theater.MovieID = MovieID;
            }

            await _context.SaveChangesAsync();
            return Ok(Theater);
        }
    }
}
