﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WildcatMicroFund.Controllers
{
    public class ReturningApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Administrator/ReturningApplication.cshtml");
        }
    }
}