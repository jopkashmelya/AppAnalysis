using System.Globalization;
using AppAnalysis.Data;
using AppAnalysis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAnalysis.Controllers;

public class AppsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _db;

    public AppsController(UserManager<User> userManager, ApplicationDbContext db)
    {
        _userManager = userManager;
        _db = db;
    }

    // GET
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _db.Users.Include(u => u.Apps).AsNoTracking()
            .FirstAsync(u => u.Id == _userManager.GetUserId(User));
        return View(user.Apps.ToList());
    }

    [Authorize]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(CreateAppViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _db.Users.FirstAsync(u => u.Id == _userManager.GetUserId(User));
            UserApp app = new()
            {
                Name = model.Name,
                CreationDate = DateTime.Now.ToUniversalTime(),
                Owner = user
            };
            await _db.Apps.AddAsync(app);
            user.Apps.Add(app);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Введите название");
        return View(model);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddEvent( EventViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _db.Users.Include(u => u.Apps).ThenInclude(app => app.Events).FirstAsync(u => u.Id == _userManager.GetUserId(User));
            var app = user.Apps.FirstOrDefault(app => app.Id == model.AppId);
            DateTime date;
            try
            {
                date = DateTime.ParseExact(model.Date, "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            }
            catch
            {
                return BadRequest();
            }

            if (app != null)
            {
                Event e = new()
                {
                    App = app,
                    Date = date,
                    Name = model.Name
                };
                app.Events.Add(e);
                await _db.SaveChangesAsync();
                
                return Ok();
            }

            return Forbid();
        }

        return BadRequest();
    }

    [HttpGet]
    [Authorize]
    public IActionResult AddEvent()
    {
        return View();
    }

    [Authorize]
    [Route("Apps/Stats/{id:int}")]
    public async Task<IActionResult> Stats(int id)
    {
        ViewData["id"] = id;

        var user = await _db.Users.Include(u => u.Apps).ThenInclude(app => app.Events).FirstAsync(u => u.Id == _userManager.GetUserId(User));
        var app = user.Apps.FirstOrDefault(app => app.Id == id);
        ViewData["appName"] = app.Name;
        return View(app.Events.OrderBy(e => e.Date));
    }

    [Authorize]
    [Route("Apps/GetEvents/{appId:int}")]
    public async Task<IEnumerable<Event>> GetEvents(int appId)
    {
        var user = await _db.Users.Include(u => u.Apps).ThenInclude(app => app.Events).FirstAsync(u => u.Id == _userManager.GetUserId(User));
        var events = user.Apps.FirstOrDefault(app => app.Id == appId).Events.OrderBy(e => e.Date);
        return events;
    }
}