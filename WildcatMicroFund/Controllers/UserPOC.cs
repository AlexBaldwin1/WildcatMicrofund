using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WildcatMicroFund.Data.Context;
using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.Controllers
{
    public class UserPOC : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public UserPOC(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        // GET: UserPOC
        public async Task<IActionResult> Index()
        {
            var wildcatMicroFundDatabaseContext = _context.Users.Include(u => u.Ethnicity).Include(u => u.Gender).Include(u => u.UserBusinesses).ThenInclude(ub => ub.Business)
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
               ;
            return View(await wildcatMicroFundDatabaseContext.ToListAsync());
        }

        // GET: UserPOC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var user = await _context.Users
                .Include(u => u.Ethnicity)
                .Include(u => u.Gender)
                .Include(u => u.UserRoles)
                .Include(u => u.UserBusinesses)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: UserPOC/Create
        public IActionResult Create()
        {
            ViewData["EthnicityID"] = new SelectList(_context.Ethnicities, "ID", "EthnicityDescription");
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Description");
            ViewData["RolesID"] = new SelectList(_context.Roles, "ID", "RoleDescription");
            return View();
        }

        // POST: UserPOC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,FirstName,LastName,PhoneNumber,GenderID,EthnicityID,StreetAddress,City,State,Zip")] User user)
        {
            if (ModelState.IsValid)
            {
                UserRole userRoleApp = new UserRole();



                userRoleApp.Role = _context.Roles
                    .Where(s => s.RoleDescription == "Applicant")
                    .FirstOrDefault();

                userRoleApp.User = user;

                

               // user.UserRoles.Add(item: userRoleApp);

                _context.Add(user);
                _context.Add(userRoleApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EthnicityID"] = new SelectList(_context.Ethnicities, "ID", "EthnicityDescription", user.EthnicityID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Description", user.GenderID);
            ViewData["RolesID"] = new SelectList(_context.Roles, "ID", "RoleDescription",user.UserRoles.ElementAt(0));
            return View(user);
        }

        // GET: UserPOC/Edit/5
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

        // POST: UserPOC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["EthnicityID"] = new SelectList(_context.Ethnicities, "ID", "EthnicityDescription", user.EthnicityID);
            ViewData["GenderID"] = new SelectList(_context.Genders, "ID", "Description", user.GenderID);
            return View(user);
        }

        // GET: UserPOC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Ethnicity)
                .Include(u => u.Gender)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserPOC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }



        [HttpPost]
        public FileResult Export()
        {
            var wildcatMicroFundDatabaseContext = _context.Users.Include(u => u.Ethnicity).Include(u => u.Gender).Include(u => u.UserBusinesses).ThenInclude(ub => ub.Business)
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
               ;


            List<User> Users = wildcatMicroFundDatabaseContext.ToList();

            


            //Insert the Column Names.
        

            StringBuilder sb = new StringBuilder();

            sb.Append("First Name, Last Name, Ethicity, Gender, City, Email, ");
            sb.Append("\r\n");

            for (int i = 0; i < Users.Count; i++)
            {
                
                    //Append data with separator.
                    sb.Append(Users[i].FirstName + ',');
                sb.Append(Users[i].LastName + ',');
                sb.Append(Users[i].Ethnicity.EthnicityDescription + ',');
                sb.Append(Users[i].Gender.Description + ',');
                sb.Append(Users[i].City + ',');
                sb.Append(Users[i].Email + ',');


                //Append new line character.
                sb.Append("\r\n");

            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }
    }



}
