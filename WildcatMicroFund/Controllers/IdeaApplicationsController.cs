using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WildcatMicroFund.Data.Context;
using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.Views
{
    public class IdeaApplicationsController : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public IdeaApplicationsController(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        // GET: IdeaApplications
        public async Task<IActionResult> Index()
        {
            var wildcatMicroFundDatabaseContext = _context.IdeaApplications.Include(i => i.BusinessStage).Include(i => i.BusinessType).Include(i => i.ConceptStatus);
            return View(await wildcatMicroFundDatabaseContext.ToListAsync());
        }

        // GET: IdeaApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaApplication = await _context.IdeaApplications
                .Include(i => i.BusinessStage)
                .Include(i => i.BusinessType)
                .Include(i => i.ConceptStatus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ideaApplication == null)
            {
                return NotFound();
            }

            return View(ideaApplication);
        }

        // GET: IdeaApplications/Create
        public IActionResult Create()
        {
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription");
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription");
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription");
            return View();
        }

        // POST: IdeaApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Concept,ConceptStatusID,SalesGenerated,SalesGeneratedInformation,BusinessStageID,BusinessIdeaDescription,HasPrototypeOrIntellectualProperty,PrototypeDescription,BusinessTypeID,MarketOpportunity,EvidenceOfViableOpportunity,CustomerDescription,MarketingAndSales,BusinessCosts,CompetitionDescription,TeamDescription,SpecificRequest")] IdeaApplication ideaApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ideaApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription", ideaApplication.BusinessStageID);
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription", ideaApplication.BusinessTypeID);
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription", ideaApplication.ConceptStatusID);
            return View(ideaApplication);
        }

        // GET: IdeaApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaApplication = await _context.IdeaApplications.FindAsync(id);
            if (ideaApplication == null)
            {
                return NotFound();
            }
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription", ideaApplication.BusinessStageID);
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription", ideaApplication.BusinessTypeID);
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription", ideaApplication.ConceptStatusID);
            return View(ideaApplication);
        }

        // POST: IdeaApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Concept,ConceptStatusID,SalesGenerated,SalesGeneratedInformation,BusinessStageID,BusinessIdeaDescription,HasPrototypeOrIntellectualProperty,PrototypeDescription,BusinessTypeID,MarketOpportunity,EvidenceOfViableOpportunity,CustomerDescription,MarketingAndSales,BusinessCosts,CompetitionDescription,TeamDescription,SpecificRequest")] IdeaApplication ideaApplication)
        {
            if (id != ideaApplication.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideaApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaApplicationExists(ideaApplication.ID))
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
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription", ideaApplication.BusinessStageID);
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription", ideaApplication.BusinessTypeID);
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription", ideaApplication.ConceptStatusID);
            return View(ideaApplication);
        }

        // GET: IdeaApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaApplication = await _context.IdeaApplications
                .Include(i => i.BusinessStage)
                .Include(i => i.BusinessType)
                .Include(i => i.ConceptStatus)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ideaApplication == null)
            {
                return NotFound();
            }

            return View(ideaApplication);
        }

        // POST: IdeaApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ideaApplication = await _context.IdeaApplications.FindAsync(id);
            _context.IdeaApplications.Remove(ideaApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaApplicationExists(int id)
        {
            return _context.IdeaApplications.Any(e => e.ID == id);
        }
    }
}
