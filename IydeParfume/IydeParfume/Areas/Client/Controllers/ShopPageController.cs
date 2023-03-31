using IydeParfume.Database;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace IydeParfume.Areas.Client.Controllers
{
    [Area("client")]
    [Route("shoppage")]
    public class ShopPageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;


        public ShopPageController(DataContext dataContext, IBasketService basketService,
            IUserService userService, IFileService fileService)
        {
            _dataContext = dataContext;
            _basketService = basketService;
            _userService = userService;
            _fileService = fileService;
        }


        #region Index'

        [HttpGet("index", Name = "client-shoppage-index")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Filter'

        //[HttpGet("Filter", Name = "client-shoppage-filter")]
        //public async Task<IActionResult> Filter(string? searchBy = null,
        //  string? search = null, int? MinPrice = null,
        //  int? MaxPrice = null, [FromQuery] int? categoryId = null,
        //  [FromQuery] int? sizeId = null, [FromQuery] int? seasonId = null,
        //  [FromQuery] int? brandId = null, [FromQuery] int? groupId = null)
        //{

        //    return ViewComponent(nameof(ShopProduct), new
        //    {
        //        searchBy = searchBy,
        //        search = search,
        //        MinPrice = MinPrice,
        //        MaxPrice = MaxPrice,
        //        categoryId = categoryId,
        //        colorId = colorId,
        //        tagId = tagId
        //    });

        //}

        #endregion
    }
}
