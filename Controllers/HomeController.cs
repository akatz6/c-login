using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace login.Controllers
{
    public class HomeController : Controller
    {

        private YourContext _context;

        public HomeController(YourContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
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
                user.Password = model.Password;
                user.Password = Hasher.HashPassword(user, user.Password);
                user.Created_At = DateTime.Now;
                user.Updated_At = DateTime.Now;
                _context.User.Add(user);
                _context.SaveChanges();

                return View("Index", model);
            }
            return View("Index", model);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(RegisterViewModel model)
        {
            if(model.Password == null || model.Email == null){
                TempData["login"] = false;
                return RedirectToAction("Index");
            }   
            var pass = _context.User.FirstOrDefault(x => x.Email == model.Email);
            var Hasher = new PasswordHasher<RegisterViewModel>();
           if(pass == null)
            {
                TempData["login"] = false;
                return RedirectToAction("Index");
            }
            if(0 != Hasher.VerifyHashedPassword(model, pass.Password, model.Password))
            {
                TempData["first_name"] = pass.First_Name;
                TempData["last_name"] = pass.Last_Name;
                TempData["id"] = pass.Id;
                HttpContext.Session.SetString("Id", pass.Id.ToString());
                
                
                return View();   
            }
            TempData["login"] = false;
           
            return RedirectToAction("Index");
        }
    }
}
