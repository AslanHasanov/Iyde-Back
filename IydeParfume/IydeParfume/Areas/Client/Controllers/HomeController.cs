using Microsoft.AspNetCore.Mvc;

namespace IydeParfume.Areas.Client.Controllers
{
    [Area("client")]
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet("~/", Name = "client-home-index")]
        [HttpGet("home-index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
