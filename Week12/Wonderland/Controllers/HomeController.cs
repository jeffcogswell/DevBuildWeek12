using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wonderland.Models;

namespace Wonderland.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog(long id)
        {
            Blog1 blog = Blog1.Read(id);
            return View(blog);
        }

        public IActionResult Add()
        {
            ViewBag.PageName = "Add";
            return View();
        }

        public IActionResult SaveNew(long id, string title, string paragraphs)
        {
            if (id >= 1)
            {
                Blog1.Update(id, title, paragraphs);
            }
            else
            {
                Blog1.Create(title, paragraphs);
            }
            ViewBag.Message = "Your entry has been saved.";
            List<Blog1> blogs = Blog1.Read();
            return View("Test",blogs);
        }

        public IActionResult Edit(long id)
        {
            ViewBag.PageName = "Edit";
            Blog1 blog = Blog1.Read(id);
            ViewBag.id = blog.id;
            ViewBag.title = blog.title;
            ViewBag.paragraphs = blog.paragraphs;
            return View("Add");
        }

        public IActionResult Test(string search)
        {
            List<Blog1> blogs = Blog1.Read(search);
            return View(blogs);
        }

        public IActionResult Test2()
        {
            //Blog1.Update(4, "AAAAA", "BBBBBB");
            long result = Blog1.TestProc();
            return Content(result.ToString());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
