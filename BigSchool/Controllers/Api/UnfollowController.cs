using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers.Api
{
    public class UnfollowController : ApiController
    {
        private ApplicationDbContext _dbContext { get; set; }
        public UnfollowController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Followings.Single(c => c.FollowerId == userId && c.FolloweeId == id);


            _dbContext.Followings.Remove(course);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
