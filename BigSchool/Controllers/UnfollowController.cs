using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class UnfollowController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public UnfollowController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string idfollower ,string idfollowee,int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Followings.Single(c => c.FollowerId == idfollower && c.FolloweeId == idfollowee);
            _dbContext.Followings.Remove(course);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
