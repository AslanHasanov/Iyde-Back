using IydeParfume.Areas.Client.ViewModels.Home;

namespace IydeParfume.Areas.Client.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public List<Images>? ImgUrl { get; set; }
        public int? SizeId { get; set; }
        public int? PersonSize { get; set; }
        public List<SizeViewModeL>? Sizes { get; set; }
        public int Quantity { get; set; }

        public List<CategoryViewModel>? Categories { get; set; }
        public List<TagViewModeL>? Tags { get; set; }
        public List<ProductListItemViewModel> Products { get; set; }









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


        public class TagViewModeL
        {
            public TagViewModeL()
            {

            }
            public TagViewModeL(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}
