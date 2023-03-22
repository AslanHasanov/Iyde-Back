using IydeParfume.Areas.Client.ViewComponents;
using IydeParfume.Areas.Client.ViewModels.Basket;
using IydeParfume.Database;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace IydeParfume.Areas.Client.Controllers
{
    [Area("client")]
    [Route("Basket")]
    public class BasketController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly IBasketService _basketService;

        public BasketController(DataContext dbContext, IUserService userService, IBasketService basketService)
        {
            _dataContext = dbContext;
            _userService = userService;
            _basketService = basketService;
        }
        #region Index'

        [HttpGet("cardpageindex", Name = "client-basket-index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        #endregion

        #region Add'

        [HttpGet("add/{id}", Name = "client-basket-add")]
        public async Task<IActionResult> AddProduct([FromRoute] int id)
        {
            var product = await _dataContext.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            var productCookiViewModel = await _basketService.AddBasketProductAsync(product);
            if (productCookiViewModel.Any())
            {
                return ViewComponent(nameof(Basket), productCookiViewModel);
            }

            return ViewComponent(nameof(Basket));
        }
        #endregion

        #region Delete'

        [HttpGet("card-page-delete/{productId}", Name = "client-basket-delete")]
        public async Task<IActionResult> DeleteBaketProductAsync([FromRoute] int productId)
        {
            if (_userService.IsAuthenticated)
            {
                var basketProduct = await _dataContext.BasketProducts.Include(p => p.Basket)
                    .FirstOrDefaultAsync(bp => bp.Basket!.UserId == _userService.CurrentUser.Id && bp.ProductId == productId);


                if (basketProduct is null) return NotFound();


                _dataContext.BasketProducts.Remove(basketProduct);
            }
            else
            {

                var product = await _dataContext.Products.FirstOrDefaultAsync(b => b.Id == productId);

                if (product is null) { return NotFound(); }


                var productCookieValue = HttpContext.Request.Cookies["products"];

                if (productCookieValue is null) { return NotFound(); }


                var productsCookieViewModel = JsonSerializer.Deserialize<List<BasketCookieViewModel>>(productCookieValue);
                productsCookieViewModel!.RemoveAll(pcvm => pcvm.Id == productId);

                HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productsCookieViewModel));
            }


            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("client-basket-index");
        }
        #endregion

        #region Individual Delete'

        [HttpGet("basket-individual-delete/{id}", Name = "client-individual-basket-delete")]
        public async Task<IActionResult> DeleteIndividualProduct([FromRoute] int id)
        {

            var productCookieViewModel = new List<BasketCookieViewModel>();
            if (_userService.IsAuthenticated)
            {

                var basketProduct = await _dataContext.BasketProducts
                    .Include(p => p.Basket)
                    .FirstOrDefaultAsync(bp => bp.Basket!.UserId == _userService.CurrentUser.Id && bp.ProductId == id);

                if (basketProduct is null) { return NotFound(); }


                if (basketProduct.Quantity > 1)
                {
                    basketProduct.Quantity -= 1;
                }
                else
                {
                    _dataContext.BasketProducts.Remove(basketProduct);
                }
            }
            else
            {
                var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product is null)
                {
                    return NotFound();
                }
                var productCookieValue = HttpContext.Request.Cookies["products"];
                if (productCookieValue is null)
                {
                    return NotFound();
                }

                productCookieViewModel = JsonSerializer.Deserialize<List<BasketCookieViewModel>>(productCookieValue);

                foreach (var cookieItem in productCookieViewModel!)
                {
                    if (cookieItem.Quantity > 1)
                    {
                        cookieItem.Quantity -= 1;
                        cookieItem.Total = cookieItem.Quantity * cookieItem.Price;
                    }
                    else
                    {
                        productCookieViewModel.RemoveAll(p => p.Id == cookieItem.Id);
                        break;
                    }
                }
                HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productCookieViewModel));
            }
            await _dataContext.SaveChangesAsync();
            return ViewComponent(nameof(Basket), productCookieViewModel);
        }
        #endregion

        #region Update'

        //[HttpGet("update", Name = "client-cardpagebasket-update")]
        //public async Task<IActionResult> UpdateProduct()
        //{
        //    return ViewComponent(nameof(BasketMini));
        //}
        #endregion
    }
}
