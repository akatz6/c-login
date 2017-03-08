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
    public class JobController : Controller
    {
        private CraigsListDBContext _context;

        public JobController(CraigsListDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("jobsInfo")]
        public IActionResult JobInfo()
        {
            ViewBag.Jobs = _context.Job.ToList();
            ViewBag.User = HttpContext.Session.GetInt32("Id");
            if(ViewBag.User == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            return View("Job");
        }

        [HttpPost]
        [Route("addJob")]
        public IActionResult AddJob(Job job)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if(userId == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            if(ModelState.IsValid)
            {
                Job career = new Job();
                career.Title = job.Title;
                career.Salary = job.Salary;
                career.CreatedAt = DateTime.Now;
                career.UpdatedAt = DateTime.Now;
                career.UserId = (int)userId;
                _context.Job.Add(career);
                _context.SaveChanges();
                return RedirectToAction("JobInfo");
            }
            ViewBag.User = userId;
            ViewBag.Jobs = _context.Job.ToList();
            return View("Job", job);
        }

        [HttpGet]
        [Route("removeJob")]
        public IActionResult RemoveJob(int id)
        {
            Job job = _context.Job.FirstOrDefault(career => career.Id == id);
            _context.Job.Remove(job);
            _context.SaveChanges();
            return RedirectToAction("JobInfo");
        }

        [HttpGet]
        [Route("conversationJob")]
        public IActionResult ConversationJob(int id)
        {
            ViewBag.userId = HttpContext.Session.GetInt32("Id");
            if(ViewBag.userId == null)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            ViewBag.Job = _context.Job.FirstOrDefault(job => job.Id == id);
            ViewBag.JobTalk = _context.JobTalk.Where(talk => talk.JobId == id);
            HttpContext.Session.SetInt32("AutoId", id);
            return View();
        }
        
        [HttpPost]
        [Route("addJobTalk")]
        public IActionResult AddJobTalk(JobTalk talk)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if(userId == null)
            {
                return RedirectToAction("LoginPage", "Login");
            } 
            var jobId = HttpContext.Session.GetInt32("AutoId");
            if(ModelState.IsValid)
            {
                JobTalk jobTalk = new JobTalk();
                jobTalk.Comment = talk.Comment;
                jobTalk.CreatedAt = DateTime.Now;
                jobTalk.JobId  = (int)jobId;
                jobTalk.UpdatedAt = DateTime.Now;
                jobTalk.UserId = (int)userId;
                _context.JobTalk.Add(jobTalk);
                _context.SaveChanges();
                return RedirectToAction("ConversationJob", new {id = jobId});
            }
            ViewBag.userId = userId;
            ViewBag.Job = _context.Job.FirstOrDefault(job => job.Id == jobId);
            ViewBag.JobTalk = _context.JobTalk.Where(jtalk => jtalk.JobId == jobId);
            return View("ConversationJob", talk);
        }

        [HttpGet]
        [Route("removeJobTalk")]
        public IActionResult RemoveJobTalk(int id)
        {
            JobTalk jobTalk = _context.JobTalk.FirstOrDefault(jtalk => jtalk.Id == id);
            _context.JobTalk.Remove(jobTalk);
            _context.SaveChanges();
            return RedirectToAction("conversationJob");
        }
    }
}