using IydeParfume.Contracts.File;
using IydeParfume.Database;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IydeParfume.Areas.Client.ViewModels.ShopPage;


namespace IydeParfume.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "ShopPageProduct")]

    public class ShopPageProduct : ViewComponent
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public ShopPageProduct(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? searchBy = null, string? search = null, [FromQuery] int? sort = null,
            int? minPrice = null, int? maxPrice = null,[FromQuery] int? categoryId = null,
            [FromQuery] int? sizeId = null, [FromQuery] int? seasonId = null, [FromQuery] int? brandId = null,
            [FromQuery] int? groupId = null, [FromQuery] int? usageTimeId = null)
        {
            var productsQuery = _dataContext.Products.AsQueryable();

            if (searchBy == "Name")
            {
                productsQuery = productsQuery
                    .Where(p => p.Name!.StartsWith(search!) || Convert.ToString(p.Price).StartsWith(search!) || search == null);
            }
            else if (sort is not null)
            {
                switch (sort)
                {
                    case 1:
                        productsQuery = productsQuery.OrderBy(p => p.Name);
                        break;

                    case 2:
                        productsQuery = productsQuery.OrderByDescending(p => p.Name);
                        break;
                    case 3:
                        productsQuery = productsQuery.OrderBy(p => p.CreatedAt);
                        break;
                    case 4:
                        productsQuery = productsQuery.OrderBy(p => p.Price);
                        break;
                    case 5:
                        productsQuery = productsQuery.OrderByDescending(p => p.Price);
                        break;
                }
            }
            else if (minPrice is not null && maxPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            }
            else if (categoryId is not null || sizeId is not null || seasonId is not null || brandId is not null
                || groupId is not null || usageTimeId is not null)
            {
                productsQuery = productsQuery
                    .Include(p => p.ProductCategories)
                    .Include(p => p.ProductSizes)
                    .Include(p => p.ProductSeasons)
                    .Include(p => p.ProductBrands)
                    .Include(p => p.ProductGroups)
                    .Include(p => p.ProductUsageTimes)
                    .Where(p => categoryId == null || p.ProductCategories!.Any(pc => pc.CategoryId == categoryId))
                    .Where(p => seasonId == null || p.ProductSeasons!.Any(pt => pt.SeasonId == seasonId))
                    .Where(p => brandId == null || p.ProductBrands!.Any(pt => pt.BrandId == brandId))
                    .Where(p => groupId == null || p.ProductGroups!.Any(pt => pt.GroupId == groupId))
                    .Where(p => usageTimeId == null || p.ProductUsageTimes!.Any(pt => pt.UsageTimeId == usageTimeId));

            }
            else
            {
                productsQuery = productsQuery.OrderBy(p => p.Price);
            }

            //var newProduct = await productsQuery.Include(p=>p.ProductBrands).ToListAsync();

            var newProduct = await productsQuery
               
                .Select(p => new ListItemViewModel(p.Id, p.Name!, p.Description!, p.Price,p.CreatedAt,
                               p.ProductImages!.Take(1).FirstOrDefault() != null
                               ? _fileService.GetFileUrl(p.ProductImages!.Take(1).FirstOrDefault()!.ImageNameFileSystem, UploadDirectory.Products)
                               : string.Empty,
                                

                                p.ProductBrands!.Select(p => p.Brand).Select(p => new ListItemViewModel.BrandListItemViewModel(p.Id,p!.Name!)).ToList()
                                )).ToListAsync();

            return View(newProduct);



           
        }
    }
}  
