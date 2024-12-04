using ProductApi.Models;
using System;

namespace ProductApi.Data_Access
{
    public static class SeedData
    {
        public static void Initialize(ProductDbContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(
                    new Product
                    {
                        ProductNumber = "P1001",
                        Name = "Laptop",
                        Description = "High-performance laptop for gaming and work",
                        StockQuantity = 50
                    },
                    new Product
                    {
                        ProductNumber = "P1002",
                        Name = "Wireless Mouse",
                        Description = "Ergonomic wireless mouse with adjustable DPI",
                        StockQuantity = 150
                    },
                    new Product
                    {
                        ProductNumber = "P1003",
                        Name = "Keyboard",
                        Description = "Mechanical keyboard with RGB backlighting",
                        StockQuantity = 100
                    },
                    new Product
                    {
                        ProductNumber = "P1004",
                        Name = "Monitor",
                        Description = "27-inch 4K UHD monitor with HDR support",
                        StockQuantity = 30
                    },
                    new Product
                    {
                        ProductNumber = "P1005",
                        Name = "External SSD",
                        Description = "1TB external SSD with USB 3.1 support",
                        StockQuantity = 75
                    }
                );
                dbContext.SaveChanges();
            }
        }
    }
}
