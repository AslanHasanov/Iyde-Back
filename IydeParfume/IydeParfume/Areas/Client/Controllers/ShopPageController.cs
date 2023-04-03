﻿using IydeParfume.Areas.Client.ViewComponents;
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

        [HttpGet("filter", Name = "client-shoppage-filter")]
        public async Task<IActionResult> Sort(string? searchBy, string? search, 
            [FromQuery] int? sort = null,
            [FromQuery] int? categoryId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            [FromQuery] int? seasonId = null,
            [FromQuery] int? brandId = null,
            [FromQuery] int? groupId = null,
            [FromQuery] int? usageTimeId = null)
        {

            return ViewComponent(nameof(ShopPageProduct), new { searchBy = searchBy, search = search, sort = sort,
                categoryId = categoryId, minPrice = minPrice, maxPrice = maxPrice, tagId = seasonId,brandId=brandId,
            groupId=groupId,usageTimeId=usageTimeId});
        }

        #endregion
    }
}
