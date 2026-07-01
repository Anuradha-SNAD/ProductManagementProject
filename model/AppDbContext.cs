using Microsoft.EntityFrameworkCore;
using ProductManagement.Model;

namespace ProductManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }
             
    }
}
