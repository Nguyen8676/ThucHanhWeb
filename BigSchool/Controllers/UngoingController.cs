using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    public class UngoingController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public UngoingController()
        {
            _dbContext = new ApplicationDbContext();
        }



    }
}
