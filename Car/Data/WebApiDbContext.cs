using Car.Shared;
using Microsoft.EntityFrameworkCore;

namespace Car.Data
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Work> Works { get; set; }
    }
}
