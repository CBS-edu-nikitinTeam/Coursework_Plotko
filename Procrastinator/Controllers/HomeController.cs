using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procrastinator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public IActionResult Contacts()
        {
            //Failed to load resource: the server responded with a status of 404 () [https://localhost:44365/Home/js/breakpoints.min.js]
            ViewBag.Title = "Contacts";
            return View();
        }
    }
}
