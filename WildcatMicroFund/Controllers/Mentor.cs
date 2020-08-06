using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WildcatMicroFund.Data.Context;
using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.Controllers
{
    public class Mentor : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public Mentor(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index() //for the index 
        {
            return View();
        }

        public async Task<IActionResult> AccessReports() //to display the AccessReports page 
        {
            return View();
        }

        public async Task<IActionResult> BusinessDashboard() //to display the Businessdashboard page 
        {
            return View();
        }

        public async Task<IActionResult> EditBusiness() //to display the EditBusiness page 
        {
            return View();
        }

        public async Task<IActionResult> MentorReport() //to display the MentorReport page 
        {
            return View();
        }

        public async Task<IActionResult> ReviewApplication() //to display the ReviewApplication page 
        {
            return View();
        }


    }
}
