using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WildcatMicroFund.Data.Context;
using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.Controllers
{
    public class Administrator : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public Administrator(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        /*        public IActionResult Index()
                {
                    return View();
                }*/

        public async Task<IActionResult> Index()
        {
            //return new Task(Task.Run(a => new View());
            return View();
        }


        public async Task<IActionResult> Users()
        {

            /*            if (id == null)
                        {
                            return NotFound();
                        }*/


            var user = _context.Users;
                //.Include(u => u.UserRoles);

/*            if (user == null)
            {
                return NotFound();
            }*/

            return View(user);

        }

        public async Task<IActionResult> Assign()
        {
            return View();
        }
    }
}