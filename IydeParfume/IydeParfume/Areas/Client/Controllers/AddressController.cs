using IydeParfume.Database;
using IydeParfume.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using IydeParfume.Areas.Client.ViewModels.Address;
using Microsoft.EntityFrameworkCore;
using IydeParfume.Database.Models;

namespace IydeParfume.Areas.Client.Controllers;

[Area("client")]
[Route("address")]
public class AddressController : Controller
{
    private readonly DataContext _dataContext;
    private readonly IUserService _userService;

    public AddressController(DataContext dataContext, IUserService userService)
    {
        _dataContext = dataContext;
        _userService = userService;
    }

    #region List'

    [HttpGet("list/{id}", Name = "client-address-list")]
    public async Task<IActionResult> List([FromRoute] int id)
    {
        var user = await _dataContext.Users.FindAsync(id);
        if (user == null) { return NotFound(); }


        var model = _dataContext.Addresses.Where(a=>a.UserId == user.Id)
                .Select(b => new ListItemViewModel(b.Id, b.AddressName, b.FullAddress, b.City, b.Phone))
                .ToList();
        return View(model); 
    }

    #endregion

    #region Add'

    [HttpGet("add/{id}", Name = "client-address-add")]
    public async Task<IActionResult> Add([FromRoute] int id)
    {
        return View();
    }
    [HttpPost("addadress{id}", Name = "client-addaddress-add")]
    public async Task<IActionResult> Add(AddViewModel model, int id)
    {

        if (!ModelState.IsValid) return View(model);

        var user = await _dataContext.Users.FirstOrDefaultAsync(u=> u.Id == _userService.CurrentUser.Id && u.Id ==id  );

        //burda useri necese vermeliyik.fikirlesel

        var address = new Address
        {
            UserId = _userService.CurrentUser.Id,
            AddressName = model.AddressName,
            FullAddress = model.FullAddress,
            City = model.City,
            Phone = model.Phone,
        };
        await _dataContext.Addresses.AddAsync(address);
        await _dataContext.SaveChangesAsync();
        return RedirectToRoute("client-address-list");
    }
    #endregion
}

