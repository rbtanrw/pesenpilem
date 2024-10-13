using Microsoft.AspNetCore.Mvc;
using SE_Project.Data;
using SE_Project.Models;
using SQLitePCL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SE_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/<CustomersController>/5
        // Login
        [HttpGet("{Email}, {Password}")]

        public ActionResult<Customer> Get(string Email, string Password) 
        {
            var user = _context.Customers.FirstOrDefault(x => x.Email == Email);
            if (user == null)
            {
                return NotFound("Email not registered");
            }

            if (user.Pass != Password)
            {
                return BadRequest("Incorrect password");
            }

            return Ok(user);
        }

        // POST api/<CustomersController>
        // Register
        [HttpPost("{Name}, {Email}, {Password}")]
        public async Task<ActionResult> PostAsync(string Name, string Email, string Password)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(_context.Customers.Any(x => x.Email == Email)) 
            {
                return BadRequest("Email has been used");
            }

            var i = 0;
            foreach(Customer customer in _context.Customers)
            {
                i++;
            }

            var user = new Customer
            {
                CustomerID = string.Concat("U", i.ToString("D3")),
                CustomerName = Name,
                Email = Email,
                Pass = Password
            };

            _context.Customers.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
