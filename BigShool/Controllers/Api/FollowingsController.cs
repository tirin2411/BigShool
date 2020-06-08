using BigShool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigShool.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(string lecturerId)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Followings.Single(c => c.FolloweeId == lecturerId && c.FollowerId == userId);
            if (course.IsCanceled)
                return NotFound();
            course.IsCanceled = true;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}