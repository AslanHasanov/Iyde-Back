using IydeParfume.Areas.Admin.ViewModels.Product;

namespace IydeParfume.Areas.Client.ViewModels.Basket
{
    public class BasketCookieViewModel
    {
        public BasketCookieViewModel(int id, string? title, string? ımageUrl, List<SizeListItemViewModel> sizes, int? sizeId, int quantity, decimal price, decimal total)
        {
            Id = id;
            Title = title;
            ImageUrl = ımageUrl;
            Sizes = sizes;
            SizeId = sizeId;
            Quantity = quantity;
            Price = price;
            Total = total;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public List<SizeListItemViewModel> Sizes { get; set; }
        public int? SizeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
       

      
    }
}
