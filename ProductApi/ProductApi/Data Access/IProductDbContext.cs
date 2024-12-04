using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data_Access
{
    public interface IProductDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
