using IydeParfume.Database;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace IydeParfume.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/product")]
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
