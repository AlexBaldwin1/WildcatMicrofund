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
    public class ApplicationPOC : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public ApplicationPOC(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        // GET: ApplicationPOC
        public async Task<IActionResult> Index()
        {
            var wildcatMicroFundDatabaseContext = _context.Applications.Include(a => a.Business).Include(a => a.Survey).Include(a => a.User);
            return View(await wildcatMicroFundDatabaseContext.ToListAsync());
        }

        // GET: ApplicationPOC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(a => a.Business)
                .Include(a => a.Survey)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: ApplicationPOC/Create
        public IActionResult Create()
        {
            ViewData["BusinessID"] = new SelectList(_context.Businesses, "ID", "ID");
            ViewData["SurveyID"] = new SelectList(_context.Surveys, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email");
            return View();
        }

        // POST: ApplicationPOC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BusinessID,UserID,DateApplied,AttendedWorkshop,DateOfDecision,SurveyID,ApplicationStatus")] Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessID"] = new SelectList(_context.Businesses, "ID", "ID", application.BusinessID);
            ViewData["SurveyID"] = new SelectList(_context.Surveys, "ID", "ID", application.SurveyID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", application.UserID);
            return View(application);
        }

        // GET: ApplicationPOC/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["BusinessID"] = new SelectList(_context.Businesses, "ID", "ID", application.BusinessID);
            ViewData["SurveyID"] = new SelectList(_context.Surveys, "ID", "ID", application.SurveyID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", application.UserID);
            return View(application);
        }

        // POST: ApplicationPOC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BusinessID,UserID,DateApplied,AttendedWorkshop,DateOfDecision,SurveyID,ApplicationStatus")] Application application)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessID"] = new SelectList(_context.Businesses, "ID", "ID", application.BusinessID);
            ViewData["SurveyID"] = new SelectList(_context.Surveys, "ID", "ID", application.SurveyID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", application.UserID);
            return View(application);
        }

        // GET: ApplicationPOC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(a => a.Business)
                .Include(a => a.Survey)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: ApplicationPOC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ID == id);
        }
    }
}
