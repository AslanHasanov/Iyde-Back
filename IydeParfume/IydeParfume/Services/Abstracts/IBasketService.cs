
using IydeParfume.Areas.Client.ViewModels.Basket;
using IydeParfume.Database.Models;

namespace IydeParfume.Services.Abstracts
{
    public interface IBasketService
    {
        Task<List<BasketCookieViewModel>> AddBasketProductAsync(Product product);

    }
}
