using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WildcatMicroFund.Controllers
{
    public class UserEdit : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
