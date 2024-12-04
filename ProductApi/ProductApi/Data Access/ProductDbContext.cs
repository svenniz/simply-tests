using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data_Access
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.ProductNumber).IsUnique();
            });
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        // SaveChangesAsync and SaveChanges
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
