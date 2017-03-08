using System;
using craigslist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace craigslist.Controllers
{
    public class AutoController : Controller
    {
        private CraigsListDBContext _context;

        public AutoController(CraigsListDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("autoInfo")]
        public IActionResult AutoInfo()
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if(userId == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            ViewBag.Cars = _context.Auto.ToList();
            ViewBag.User = (int)userId;
            return View("Auto");
        }
        [HttpPost]
        [Route("addAuto")]
        public IActionResult AddAuto(Auto car)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if(userId == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            if(ModelState.IsValid)
            {
                Auto auto = new Auto();
                auto.Make = car.Make;
                auto.Model = car.Model;
                auto.Part = car.Part;
                auto.Price = car.Price;
                auto.CreatedAt = DateTime.Now;
                auto.UpdatedAt = DateTime.Now;
                auto.UserId = (int)userId;
                _context.Auto.Add(auto);
                _context.SaveChanges();
                return RedirectToAction("AutoInfo");
            }
            return View("Auto", car);
        }
        [HttpGet]
        [Route("removeAuto")]
        public IActionResult RemoveAuto(int id)
        {
            Auto auto = _context.Auto.FirstOrDefault(car => car.Id == id);
            var userId = HttpContext.Session.GetInt32("Id");
            if(auto == null || auto.UserId != userId)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            _context.Auto.Remove(auto);
            _context.SaveChanges();
            return RedirectToAction("AutoInfo");
        }

        [HttpGet]
        [Route("removeAutoConversation")]
        public IActionResult RemoveAutoConversation(int id)
        {
            AutoTalk autoTalk = _context.AutoTalk.FirstOrDefault(cartalk => cartalk.Id == id);
            var userId = HttpContext.Session.GetInt32("Id");
            if(autoTalk == null || autoTalk.UserId != userId)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            _context.AutoTalk.Remove(autoTalk);
            _context.SaveChanges();
            var carId = HttpContext.Session.GetInt32("CarId");
            return RedirectToAction("ConversationAuto", new {id = carId});
        }

        [HttpGet]
        [Route("conversationAuto")]
        public IActionResult ConversationAuto(int id)
        {
            ViewBag.user = HttpContext.Session.GetInt32("Id");
            if(ViewBag.user == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            HttpContext.Session.SetInt32("CarId", id);
            ViewBag.Auto = _context.Auto.FirstOrDefault(car => car.Id == id);
            ViewBag.Conversations = _context.AutoTalk.Where(talk => talk.CarId  == id).Include(x => x.User).ToList();    
            return View();
        }

        [HttpPost]
        [Route("addAutoTalk")]
        public IActionResult AddAutoTalk(AutoTalk talk)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if(userId == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            var carId = HttpContext.Session.GetInt32("CarId");
            if(ModelState.IsValid)
            {
                AutoTalk autoTalk = new AutoTalk();
                autoTalk.Comment = talk.Comment;
                autoTalk.CarId = (int)carId;
                autoTalk.UserId = (int)userId;
                autoTalk.CreatedAt = DateTime.Now;
                autoTalk.UpdatedAt = DateTime.Now;
                _context.AutoTalk.Add(autoTalk);
                _context.SaveChanges();
                return RedirectToAction("ConversationAuto", new {id = carId});
            }
            ViewBag.Auto = _context.Auto.FirstOrDefault(car => car.Id == carId);
            ViewBag.Conversations = _context.AutoTalk.Include(x => x.User).ToList();
            return View("ConversationAuto", talk);
        }
    }
}