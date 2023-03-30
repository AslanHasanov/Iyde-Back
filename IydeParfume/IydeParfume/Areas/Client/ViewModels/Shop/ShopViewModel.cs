using IydeParfume.Areas.Client.ViewModels.Home;

namespace IydeParfume.Areas.Client.ViewModels.Shop
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<Images>? ImgUrl { get; set; }
        public int? SizeId { get; set; }
        public int? PrSize { get; set; }
        public List<SizeViewModeL>? Sizes { get; set; }
        public int Quantity { get; set; }

        public List<CategoryViewModel>? Categories { get; set; }
        public List<SeasonViewModel>? Seasons { get; set; }
        public List<BrandViewModel>? Brands { get; set; }
        public List<GroupViewModel>? Groups { get; set; }
        public List<UsageTimeViewModel>? UsageTimes { get; set; }

        public List<ShopListItemViewModel> Products { get; set; }









        public class Images
        {
            public Images()
            {

            }
            public Images(int id, string imageUrl)
            {
                Id = id;
                ImageUrl = imageUrl;
            }

            public int Id { get; set; }
            public string ImageUrl { get; set; }
        }

        public class SizeViewModeL
        {
            public SizeViewModeL()
            {

            }
            public SizeViewModeL(int title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public int Title { get; set; }
        }

        public class CategoryViewModeL
        {
            public CategoryViewModeL(string title, int id)
            {
                Title = title;
                Id = id;
            }
            public CategoryViewModeL()
            {

            }

            public int Id { get; set; }
            public string Title { get; set; }
        }


        public class SeasonViewModel
        {
            public SeasonViewModel()
            {

            }
            public SeasonViewModel(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }
        public class BrandViewModel
        {
            public BrandViewModel()
            {

            }
            public BrandViewModel(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }
        public class GroupViewModel
        {
            public GroupViewModel()
            {

            }
            public GroupViewModel(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }
        public class UsageTimeViewModel
        {
            public UsageTimeViewModel()
            {

            }
            public UsageTimeViewModel(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}
