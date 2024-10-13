using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SE_Project.Data;
using SE_Project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SE_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public List<TransactionDetail> Get()
        {
            var trList = _context.TransactionDetails.Select(x => new TransactionDetail
            {
                TransactionID = x.TransactionID,
                CustomerID = x.CustomerID,
                TransactionDate = x.TransactionDate,
                SeatID = x.SeatID,
            });

            return trList.ToList();
        }

        // GET api/<TransactionController>/5
        // Get History
        [HttpGet("{CustomerID}")]
        public List<TransactionDetail> Get(string CustomerID)
        {
            if (!_context.Customers.Any(x => x.CustomerID == CustomerID))
            {
                return null;
            }

            var customer = _context.Customers.FirstOrDefault(x => x.CustomerID == CustomerID);
            if(customer == null)
            {
                return null;
            }

            var trList = _context.TransactionDetails.Where(x => x.CustomerID == CustomerID).Select(x => new TransactionDetail
            {
                TransactionID = x.TransactionID,
                TransactionDate = x.TransactionDate,
                CustomerID = x.CustomerID,
                SeatID = x.SeatID
            });

            return trList.ToList() ;
        }

        [HttpPost("{CustomerID}, {SeatID}")]
        public async Task<ActionResult> PostAsync(string CustomerID, string SeatID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Customers.Any(x => x.CustomerID == CustomerID))
            {
                return NotFound("Invalid CustomerID");
            }
            if (!_context.Seats.Any(x => x.SeatID == SeatID))
            {
                return NotFound("Invalid SeatID");
            }

            var i = 0;
            foreach (TransactionDetail td in _context.TransactionDetails)
            {
                i++;
            }

            var transaction = new TransactionDetail
            {
                TransactionID = string.Concat("TR", i.ToString("D2")),
                TransactionDate = DateTime.Now,
                CustomerID = CustomerID,
                SeatID = SeatID
            };

            _context.TransactionDetails.Add(transaction);
            await _context.SaveChangesAsync();
            return Ok(transaction);

        }
    }
}
