using IydeParfume.Areas.Admin.ViewModels.Category;
using IydeParfume.Contracts.File;
using IydeParfume.Database;
using IydeParfume.Database.Models;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IydeParfume.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;

        public CategoryController(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        #region List'

        [HttpGet("list", Name = "admin-category-list")]
        public async Task<IActionResult> List()
        {
            var model = await _dataContext.Categories.Select(c => new ListItemViewModel(c.Id, c.Title!, c.Parent!.Title!))
                .ToListAsync();

            return View(model);
        }
        #endregion

        #region Add'

        [HttpGet("add", Name = "admin-category-add")]
        public async Task<IActionResult> Add()
        {
            var model = new AddViewModel
            {
                Catagories = await _dataContext.Categories
                   .Select(c => new ViewModels.Product.CatagoryListItemViewModel(c.Id, c.Title!))
                   .ToListAsync(),
            };
            return View(model);
        }
        [HttpPost("add", Name = "admin-category-add")]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid) return GetView(model);
         


            var category = new Category
            {
                Title = model.Title,
                ParentId = model.CategoryIds,
            };
            await _dataContext.Categories.AddAsync(category);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-category-list");


            IActionResult GetView(AddViewModel model)
            {
                model.Catagories = _dataContext.Categories
                .Select(c => new ViewModels.Product.CatagoryListItemViewModel(c.Id, c.Title!))
                   .ToList();

                return View(model);
            }
        }
        #endregion

        #region Delete'

        [HttpPost("delete/{id}", Name = "admin-category-delete")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            var category = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            var allCategories = await _dataContext.Categories.ToListAsync();

            if (category is null) return NotFound();
         

            foreach (var item in allCategories)
            {
                if (category.Id == item.ParentId)
                {
                    _dataContext.Categories.Remove(item);
                    await _dataContext.SaveChangesAsync();
                }
            }

            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-category-list");
        } 
        #endregion
    }
}
