using BigShool.Models;
using BigShool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigShool.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public LecturesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Lectures
        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();

            var follow = _dbContext.Followings
                .Where(a => a.FollowerId == userId)
                .Include(l => l.Follower)
                .Select(a => a.Followee)
                .ToList();
            var viewModel = new FollowerViewModel
            {
                Upcomming = follow,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
    }
}