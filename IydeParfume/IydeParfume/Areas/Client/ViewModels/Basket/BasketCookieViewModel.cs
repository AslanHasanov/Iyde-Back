using IydeParfume.Areas.Client.ViewModels.Basket;

namespace IydeParfume.Areas.Client.ViewModels.Basket
{
    public class BasketCookieViewModel
    {
        public BasketCookieViewModel(int id, string? title, string? ımageUrl, int quantity, decimal price, 
            decimal total, List<SizeListItemViewModel> sizes, int? sizeId, int? prSize)
        {
            Id = id;
            Title = title;
            ImageUrl = ımageUrl;
            Quantity = quantity;
            Price = price;
            Total = total;
            Sizes = sizes;
            SizeId = sizeId;
            PrSize = prSize;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public List<SizeListItemViewModel> Sizes { get; set; }
        public int? SizeId { get; set; }
        public int? PrSize { get; set; }

        public BasketCookieViewModel()
        {

        }
        public BasketCookieViewModel(int id, string? title, string? imageUrl, int quantity, int? sizeId,
            List<SizeListItemViewModel> sizes,
            int? prSize, decimal price, decimal total)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Quantity = quantity;
            SizeId = sizeId;
            Sizes = sizes;
            PrSize = prSize;
            Price = price;
            Total = total;
        }

    }
}
