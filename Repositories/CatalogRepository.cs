using CatalogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogApp
{
    public class CatalogRepository : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public CatalogRepository(DbContextOptions options, DbSet<Category> dbCategories, DbSet<Product> dbProduct) :
            base(options)
        {
        }
    }
}