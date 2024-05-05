using Car.Shared;
using Microsoft.EntityFrameworkCore;

namespace Car.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Work> Works { get; set; }
    }
}
