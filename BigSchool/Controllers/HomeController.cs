using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BigSchool.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourses = _dbContext.Courses.Include(c => c.Lecturer).Include(c => c.Category).Where(c => c.DateTime > DateTime.Now);

         

            var userId = User.Identity.GetUserId();

            var attendanced = _dbContext.Attendances.Where(a => a.AttendeeId == userId)
                                                    .Select(a => a.CourseId)
                                                    .ToList();

            var followeed = _dbContext.Followings.Where(a => a.FollowerId == userId)
                                                .Select(a => a.FolloweeId)
                                                .ToList();


            var viewModel = new CourseViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated,
                attendances = attendanced,
                followed = followeed 
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public string GetAttendance()
        //{
        //    var userId = User.Identity.GetUserId();
           
        //    var attendanced = _dbContext.Attendances.Where(a => a.AttendeeId == userId)
        //                                       .Include(a => a.CourseId)
        //                                       .Include(a => a.Course.Id)
        //                                       .Where(a=>a.CourseId==a.Course.Id)
        //                                       .ToList();

        //    var viewModel = new CourseViewModel
        //    {
        //        attendances = attendanced,
        //    };

            
                
     
            
            
  
        //}

       
    }
}