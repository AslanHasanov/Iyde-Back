using System.ComponentModel.DataAnnotations;

namespace IydeParfume.Areas.Admin.ViewModels.Product
{
    public class AddViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        [Required]
        public List<int> CategoryIds { get; set; }
        [Required]
        public List<CatagoryListItemViewModel>? Catagories { get; set; }

        [Required]
        public List<int> SeasonIds { get; set; }
        [Required]
        public List<SeasonListItemViewModel>? Seasons { get; set; }

        [Required]
        public List<int> UsageTimeIds { get; set; }
        [Required]
        public List<UsageTimeListItemViewModel>? UsageTimes { get; set; }

        [Required]
        public List<int> GroupIds { get; set; }
        [Required]
        public List<GroupListItemViewModel>? Groups { get; set; }

        [Required]
        public List<int> BrandIds { get; set; }
        [Required]
        public List<BrandListItemViewModel>? Brands { get; set; }

        [Required]
        public List<int> SizeIds { get; set; }
        [Required]
        public List<SizeListItemViewModel>? Sizes { get; set; }


        [Required]
        public IFormFile MainImage { get; set; }

        [Required]
        public List<IFormFile>? AllImages { get; set; }
    }
}
