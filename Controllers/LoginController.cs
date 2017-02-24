using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using craigslist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace craigslist.Controllers
{
    public class LoginController : Controller
    {

        private CraigsListDBContext _context;

        public LoginController(CraigsListDBContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult LoginPage()
        {
            if (TempData["LoginError"] != null)
            {
                ViewBag.Error = "Username or Password do not match"; 
            }
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User user = new User();
                user.First_Name = model.First_Name;
                user.Last_Name = model.Last_Name;
                user.Email = model.Email;
                user.Password = Hasher.HashPassword(user, model.Password);
                user.Created_At = DateTime.Now;
                user.Updated_At = DateTime.Now;
                _context.User.Add(user);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToAction("CurrentSession", "Home");
            }
            return View("LoginPage", model);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(RegisterViewModel model)
        { 
            User user = _context.User.FirstOrDefault(x => x.Email == model.Email);
            var Hasher = new PasswordHasher<RegisterViewModel>();
            
            if(user != null && model.Password != null && 0 != Hasher.VerifyHashedPassword(model, user.Password, model.Password))
            {
                HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToAction("CurrentSession", "Home");  
            }

            TempData["LoginError"] = true;
            return RedirectToAction("LoginPage");
        }
    }
}
