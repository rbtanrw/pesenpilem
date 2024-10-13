using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using SE_Project.Data;
using SE_Project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SE_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SeatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/<SeatsController>/5
        // Available Seats In Theater
        [HttpGet("{TheaterID}")]
        public ActionResult<SeatsAvailability> Get(string TheaterID)
        {
            var theater = _context.Theaters.FirstOrDefault(x => x.TheaterID == TheaterID);
            if (theater == null)
            {
                return NotFound("Invalid TheaterID");
            }

            var movie = _context.Movies.FirstOrDefault(x => x.MovieID == theater.MovieID);

            int[,] infoSeat = new int[3, 10];
            for (var col = 0; col < theater.Capacity; col++)
            {
                var row = col / 10;
                string findID = string.Concat(TheaterID[3], (char)(row+'A'), (col%10).ToString("D1"));

                var Seat = _context.Seats.FirstOrDefault(x => x.SeatID == findID);

                if (Seat.CustomerID == "USER") infoSeat[row, col % 10] = -1;
                else infoSeat[row, col % 10] = 1;
            }

            var infoSeatList = Enumerable.Range(0, 3)
    .Select(row => Enumerable.Range(0, 10).Select(col => infoSeat[row, col]).TakeWhile(x => x != 0).ToList())
    .ToList();

            var info = new SeatsAvailability
            {
                TheaterID = theater.TheaterID,
                Capacity = theater.Capacity,
                Seats = infoSeatList,
                Movie = movie
            };

            return Ok(info);
        }


        // POST api/<SeatsController>

        // PUT api/<SeatsController>/5
        // Booking Seat
        [HttpPut("{SeatID}, {CustomerID}")]
        public async Task<ActionResult> PutAsync(string SeatID, string CustomerID)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (!_context.Seats.Any(x => x.SeatID == SeatID))
            {
                return NotFound("Invalid SeatID");
            }

            var Seat = _context.Seats.FirstOrDefault(x => x.SeatID == SeatID);

            if (Seat.CustomerID != "USER")
            {
                return BadRequest("Seat is Booked");
            }
            
            Seat.CustomerID = CustomerID;
            await _context.SaveChangesAsync();
            return Ok(Seat);
        }

        // PUT api/<SeatsController>/5
        // Reset Seat
        [HttpPut("{TheaterID}")]
        public async Task<ActionResult> PutAsync(string TheaterID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var theater = _context.Theaters.FirstOrDefault(x => x.TheaterID == TheaterID);
            if (theater == null)
            {
                return NotFound("Invalid TheaterID");
            }

            for (var col = 0; col < theater.Capacity; col++)
            {
                var row = col / 10;
                string findID = string.Concat(TheaterID[3], (char)(row + 'A'), (col % 10).ToString("D1"));

                var Seat = _context.Seats.FirstOrDefault(x => x.SeatID == findID);
                Seat.CustomerID = "USER";
            }

            await _context.SaveChangesAsync();
            return Ok("Reset Success");
        }
    }
}
