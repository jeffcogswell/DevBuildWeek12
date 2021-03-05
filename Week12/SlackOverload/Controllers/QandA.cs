using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlackOverload.Models;

namespace SlackOverload.Controllers
{
    public class QandA : Controller
    {
        public IActionResult Index(string username)
        {
            List<Question> questions = Models.Question.Get();
            HttpContext.Response.Cookies.Append("username", username);
            return View(questions);
        }

        public IActionResult Question(long id)
        {
            ViewBag.username = HttpContext.Request.Cookies["username"];
            Models.Question question = Models.Question.Get(id);
            return View();
        }
    }
}
