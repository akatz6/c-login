using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using idea.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace idea.Controllers
{
    public class HomeController : Controller
    {

        private IdeasDBContext _context;

        public HomeController(IdeasDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("currentSession")]
        public IActionResult CurrentSession()
        {
            var id = HttpContext.Session.GetInt32("Id");
            if (id != null)
            {
                ViewBag.User = _context.User.FirstOrDefault(user => user.Id == id);
                return View("Home");
            }
            return RedirectToAction("LoginPage", "Login");
        }
    }
}