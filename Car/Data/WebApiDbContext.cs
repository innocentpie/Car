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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
