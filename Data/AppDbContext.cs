using Microsoft.EntityFrameworkCore;
using ODC_Task2__MVC_.Models;

namespace ODC_Task2__MVC_.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
    }
}
