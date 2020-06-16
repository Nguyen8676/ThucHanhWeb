using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public LecturerController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Lecturer
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var following = _dbContext.Followings.Where(a => a.FollowerId == userId)
                                                .Select(a => a.Followee)
                                                .ToList();
            var viewModel = new FollowingViewModel
            {
                FollowingCourses = following,
                ShowAction = User.Identity.IsAuthenticated

            };
            return View(viewModel);
        }

    }
}