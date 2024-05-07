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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>()
                .HasOne<Customer>()
                .WithOne()
                .HasForeignKey<Work>(x => x.CustomerId);
        }
    }
}
