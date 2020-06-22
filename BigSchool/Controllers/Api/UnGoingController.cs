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
    public class UnGoingController : ApiController
    {
        private ApplicationDbContext _dbContext { get; set; }
        public UnGoingController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Deletegoing(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Attendances.Single(c => c.AttendeeId == userId && c.CourseId == id);


            _dbContext.Attendances.Remove(course);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
