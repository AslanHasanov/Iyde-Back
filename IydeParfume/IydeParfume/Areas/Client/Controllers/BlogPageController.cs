using IydeParfume.Areas.Client.ViewComponents;
using IydeParfume.Areas.Client.ViewModels.Blog;
using IydeParfume.Contracts.File;
using IydeParfume.Database;
using IydeParfume.Migrations;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IydeParfume.Areas.Client.Controllers
{
    [Area("client")]
    [Route("BlogPage")]
    public class BlogPageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public BlogPageController(DataContext dbContext, IFileService fileService)
        {
            _dataContext = dbContext;
            _fileService = fileService;
        }

        //[HttpGet("blogpageindex/{blogId}", Name ="client-blogPage-index")]
        //public async Task<IActionResult> Index([FromRoute] int blogId)
        //{
        //    var blogItem = await _dataContext.Blogs.FirstOrDefaultAsync(n => n.Id == blogId);

        //    if (blogItem is null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new BlogViewModel(blogItem.Id, blogItem.Title, blogItem.Content,
        //        blogItem.BlogDisplays.FirstOrDefault() != null
        //        ? _fileService.GetFileUrl(blogItem.BlogDisplays!
        //        .Take(1).FirstOrDefault()!.FileNameInSystem, Contracts.File.UploadDirectory.Blog) : String.Empty,
        //        //    blogItem.BlogDisplays!.FirstOrDefault()!.IsImage != null! ? blogItem.BlogDisplays!.FirstOrDefault()!.IsImage : default,
        //        //blogItem.BlogDisplays!.FirstOrDefault()!.IsVidio != null! ? blogItem.BlogDisplays!.FirstOrDefault()!.IsVidio : default,
        //        blogItem.CreatedAt);       

        //    return View(model);

        //}
        [HttpGet("blogpageindex/{blogId}", Name = "client-blogPage-index")]
        public async Task<IActionResult> Index([FromRoute] int blogId)
        {
            var blog = await _dataContext.Blogs.Include(b => b.BlogDisplays)
                .FirstOrDefaultAsync(b => b.Id == blogId);

            if (blog == null) return NotFound();
           
            var blogDisplay = await _dataContext.BlogDisplays.FirstOrDefaultAsync(b=>b.BlogId == blog.Id);
            if (blogDisplay == null) return NotFound();



            var blogViewModel = new BlogItemViewModel
            {
                Id = blog.Id,
                Title = blog.Title!,
                Content = blog.Content!,
                
                PostedDate = blog.CreatedAt,
                Image = blogDisplay.FileNameInSystem.FirstOrDefault() != null
                ? _fileService.GetFileUrl(blogDisplay.FileNameInSystem, UploadDirectory.Blog)
                : string.Empty
               
            };

            return View(blogViewModel);
        }


    }
}
