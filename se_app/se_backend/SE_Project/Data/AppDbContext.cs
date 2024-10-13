using Microsoft.EntityFrameworkCore;
using SE_Project.Models;

namespace SE_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}
