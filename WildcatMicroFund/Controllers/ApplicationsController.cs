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
    public class ApplicationsController : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public ApplicationsController(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var wildcatMicroFundDatabaseContext = _context.ApplicationDetails.Include(i => i.BusinessStage).Include(i => i.BusinessType).Include(i => i.ConceptStatus);
            return View(await wildcatMicroFundDatabaseContext.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaApplication = await _context.ApplicationDetails
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

        // GET: Applications/Create
        public IActionResult Create()
        {
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription");
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription");
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription");
            return View();
        }

        // POST: Applications/Create
        // Create a new application and application details.

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Concept,ConceptStatusID,SalesGenerated,SalesGeneratedInformation,BusinessStageID,BusinessIdeaDescription,HasPrototypeOrIntellectualProperty,PrototypeDescription,BusinessTypeID,MarketOpportunity,EvidenceOfViableOpportunity,CustomerDescription,MarketingAndSales,BusinessCosts,CompetitionDescription,TeamDescription,SpecificRequest")] ApplicationDetail applicationDetail)
        {
            if (ModelState.IsValid)
            {
                // Create the Application
                Application application = new Application();
                application.DateApplied = DateTime.Now;
                var applicationStatus = _context.ApplicationStatuses
                    .Where(a => a.Description == "Applicantion in work").FirstOrDefault<ApplicationStatus>();
                application.ApplicationStatus = applicationStatus;


                // Add Date to applicationDetails
                applicationDetail.DateChanged = DateTime.Now;
                
                // Add the rows to the database.
                _context.Add(application);
                await _context.SaveChangesAsync();
                applicationDetail.Application = application;
                _context.Add(applicationDetail);


                // _context.Applications.Add(application);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription", applicationDetail.BusinessStageID);
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription", applicationDetail.BusinessTypeID);
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription", applicationDetail.ConceptStatusID);
            return View(applicationDetail);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaApplication = await _context.ApplicationDetails.FindAsync(id);
            if (ideaApplication == null)
            {
                return NotFound();
            }
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription", ideaApplication.BusinessStageID);
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription", ideaApplication.BusinessTypeID);
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription", ideaApplication.ConceptStatusID);
            return View(ideaApplication);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // This will save a new application details to the database with a new date changed so old applications are saved.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Concept,ConceptStatusID,SalesGenerated,SalesGeneratedInformation,BusinessStageID,BusinessIdeaDescription,HasPrototypeOrIntellectualProperty,PrototypeDescription,BusinessTypeID,MarketOpportunity,EvidenceOfViableOpportunity,CustomerDescription,MarketingAndSales,BusinessCosts,CompetitionDescription,TeamDescription,SpecificRequest")] ApplicationDetail applicationDetail)
        {
            /*if (id != applicationDetail.ID)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                try
                {
                    // find the application to connect it to.
                    var oldApplicationDetails = _context.ApplicationDetails
                        .Where(ad => ad.ID == id).FirstOrDefault<ApplicationDetail>();

                    // Connect the new applicationDetail to the existing application.
                    applicationDetail.Application = oldApplicationDetails.Application;
                    applicationDetail.ApplicationID = oldApplicationDetails.ApplicationID;
                    applicationDetail.DateChanged = DateTime.Now;
                    _context.ApplicationDetails.Add(applicationDetail);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaApplicationExists(applicationDetail.ID))
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
            ViewData["BusinessStageID"] = new SelectList(_context.BusinessStages, "ID", "BusinessStageDescription", applicationDetail.BusinessStageID);
            ViewData["BusinessTypeID"] = new SelectList(_context.BusinessTypes, "ID", "BusinessTypeDescription", applicationDetail.BusinessTypeID);
            ViewData["ConceptStatusID"] = new SelectList(_context.ConceptStatuses, "ID", "ConceptStatusDescription", applicationDetail.ConceptStatusID);
            return View(applicationDetail);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaApplication = await _context.ApplicationDetails
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

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaApplicationExists(int id)
        {
            return _context.ApplicationDetails.Any(e => e.ID == id);
        }
    }
}
