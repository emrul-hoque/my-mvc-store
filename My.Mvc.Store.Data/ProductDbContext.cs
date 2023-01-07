using Microsoft.EntityFrameworkCore;
using My.Mvc.Store.Domain.Entities;

namespace My.Mvc.Store.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public string DbPath { get; init; }

        public ProductDbContext()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ProductDb");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlite($"Data Source={DbPath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
