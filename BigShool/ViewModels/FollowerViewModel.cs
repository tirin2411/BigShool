﻿using BigShool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigShool.ViewModels
{
    public class FollowerViewModel
    {
        public IEnumerable<ApplicationUser> Upcomming { get; set; }
        public bool ShowAction { get; set; }
    }
}