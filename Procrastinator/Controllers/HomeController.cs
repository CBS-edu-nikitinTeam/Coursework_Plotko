using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procrastinator.Settings;


namespace Procrastinator.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public IActionResult Contacts()
        {
            
            ViewBag.Title = "Contacts";
            return View();
        }
    }
}
