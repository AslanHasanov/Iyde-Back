using IydeParfume.Database;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace IydeParfume.Areas.Client.Controllers
{
    [Area("client")]
    [Route("support")]
    public class SupportController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;

        public SupportController(DataContext dataContext, IUserService userService)
        {
            _dataContext = dataContext;
            _userService = userService;
        }
        [HttpGet("dashboard", Name = "client-account-dashboard")]
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
