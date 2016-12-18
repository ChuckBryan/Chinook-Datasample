using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chinook3.Controllers
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : Controller
    {
        private readonly ChinookContext _chinookContext;

        public HomeController(ChinookContext chinookContext)
        {
            _chinookContext = chinookContext;
        }

        public IActionResult Index()
        {


            var albums = _chinookContext.Albums.ToList();

            return View(albums);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
