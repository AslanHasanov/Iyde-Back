using Microsoft.EntityFrameworkCore;
using IydeParfume.Extensions;
using IydeParfume.Database.Models;

namespace IydeParfume.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
       : base(options)
        {

        }

        public DbSet<Navbar> Navbars { get; set; }
        public DbSet<SubNavbar> SubNavbars { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<ProductSeason> ProductSeasons { get; set; }
        public DbSet<UsageTime> UsageTimes { get; set; }
        public DbSet<ProductUsageTime> ProductUsageTimes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }











        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly<Program>();
        }
    }
}
