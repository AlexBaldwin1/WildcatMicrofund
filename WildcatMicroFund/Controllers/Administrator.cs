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


        public async Task<IActionResult> Index()
        {
/*            var wildcatMicroFundDatabaseContext = _context.Users.Include(u => u.Ethnicity).Include(u => u.Gender).Include(u => u.UserBusinesses).ThenInclude(ub => ub.Business)
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
               ;
            return View(await wildcatMicroFundDatabaseContext.ToListAsync());*/
            return View();
        }


        public async Task<IActionResult> Users()
        {

            //var wildcatMicroFundDatabaseContext = _context.Users.Include(u => u.Ethnicity).Include(u => u.Gender).Include(u => u.UserBusinesses).ThenInclude(ub => ub.Business)
            //.Include(u => u.UserRoles).ThenInclude(ur => ur.Role);

            /*            if (id == null)
                        {
                            return NotFound();
                        }*/


            //var user = _context.Users;
            //.Include(u => u.UserRoles);

            /*            if (user == null)
                        {
                            return NotFound();
                        }*/

            // return View(user);

            var wildcatMicroFundDatabaseContext = _context.Users.Include(u => u.Ethnicity).Include(u => u.Gender).Include(u => u.UserBusinesses).ThenInclude(ub => ub.Business)
            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            ;
            return View(await wildcatMicroFundDatabaseContext.ToListAsync());

        }

        public async Task<IActionResult> Reports()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["EthnicityID"] = new SelectList(_context.Ethnicities, "ID", "EthnicityDescription", user.EthnicityID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Description", user.GenderID);
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,FirstName,LastName,PhoneNumber,GenderID,EthnicityID,StreetAddress,City,State,Zip")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Users));
            }
            ViewData["EthnicityID"] = new SelectList(_context.Ethnicities, "ID", "EthnicityDescription", user.EthnicityID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Description", user.GenderID);
            return View(user);
        }

/*        public async Task<IActionResult> Assign(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email");
            return View(userRole);
        }*/

        public async Task<IActionResult> Assign(int? id)
        {
            /*            List<string> roles = new List<string>();
                        roles.Add("Admin");
                        roles.Add("Applicant");*/
            /*            ViewData["RoleID"] = new SelectList(_context.Roles.Select(a => a.ID));*/
            /*            ViewData["RoleID"] = roles;*/

            {
                if (id == null)
                {
                    return NotFound();
                }

                var userRole = await _context.UserRoles
                    .Include(u => u.Role)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(m => m.UserID == id);
                if (userRole == null)
                {
                    return NotFound();
                }
/*                ViewData["Roles"] = new SelectList(_context.UserRoles, "RoleDescription", userRole.Role);*/
                ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "RoleDescription");
                ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email");
                return View(userRole);
            }

            /*            if (id == null)
                        {
                            return NotFound();
                        }

                        var userRole = _context.UserRoles
                            .Include(u => u.Role)
                            .Include(u => u.User)
                            .Where(m => m.UserID == id);
                        if (userRole == null || !userRole.Any())
                        {
                            return NotFound();
                        }

                        return View(userRole.ToList());*/
        }

        public async Task<IActionResult> ApplicationStatus() 
        {
           /* var wildcatMicroFundDatabaseContext = _context.Users.Include(u => u.Ethnicity).Include(u => u.Gender).Include(u => u.UserBusinesses).ThenInclude(ub => ub.Business)
            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            ;*/

            var wildcatMicroFundDatabaseContext2 = _context.Applications.Include(u => u.User).Include(u => u.Business).Include(u => u.ApplicationStatus)
                
                ;

            return View(await wildcatMicroFundDatabaseContext2.ToListAsync());
            //return View();
        }

        public async Task<IActionResult> ChangeStatus(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["ApplicationStatusID"] = new SelectList(_context.ApplicationStatuses, "ID", "Description", application.ApplicationStatusID);
            return View(application);
           /* var status = await _context.Applications
                    .Include(u => u.ApplicationStatus)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(m => m.ID == id);
            if (status == null)
            {
                return NotFound();
            }

            ViewData["ApplicationStatusID"] = new SelectList(_context.Applications, "ID", "ApplicationStatus");
            return View(status);*/
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ID == id);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id, [Bind("ID ,Business, BusinessID,UserID, User,DateApplied,AttendedWorkshop, DateofDecision, ApplicationDetails, ApplicationStatusID, ApplicationStatus")] Application application)
 
        {

            {
                if (id != application.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(application);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ApplicationExists(application.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(ApplicationStatus));
                }

                ViewData["ApplicationStatusID"] = new SelectList(_context.ApplicationStatuses, "ID", "Description", application.ApplicationStatusID);
                return View(application);
                /*
                var status = await _context.Applications
                    .Include(u => u.ApplicationStatus)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (status == null)
                {
                    return NotFound();
                }

                ViewData["Description"] = new SelectList(_context.ApplicationStatuses, "ID", "Description");
                return View(status);*/
            }
        }

            public async Task<IActionResult> NewApplication()
        {
            return View();
        }

    }
}