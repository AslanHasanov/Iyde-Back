using IydeParfume.Database.Models.Common;

namespace IydeParfume.Database.Models
{
    public class Product : BaseEntity<int>, IAuditable
    {
        public string? Name { get; set; }
        public int? Rate { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<ProductCategory>? ProductCategories { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        public List<ProductSeason>? ProductSeasons { get; set; }
        public List<ProductUsageTime>? ProductUsageTimes { get; set; }







    }
}
