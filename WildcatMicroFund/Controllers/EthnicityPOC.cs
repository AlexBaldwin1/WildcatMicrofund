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
    public class EthnicityPOC : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public EthnicityPOC(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        // GET: EthnicityPOC
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ethnicities.ToListAsync());
        }

        // GET: EthnicityPOC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ethnicity = await _context.Ethnicities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ethnicity == null)
            {
                return NotFound();
            }

            return View(ethnicity);
        }

        // GET: EthnicityPOC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EthnicityPOC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EthnicityDescription")] Ethnicity ethnicity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ethnicity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ethnicity);
        }

        // GET: EthnicityPOC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ethnicity = await _context.Ethnicities.FindAsync(id);
            if (ethnicity == null)
            {
                return NotFound();
            }
            return View(ethnicity);
        }

        // POST: EthnicityPOC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EthnicityDescription")] Ethnicity ethnicity)
        {
            if (id != ethnicity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ethnicity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EthnicityExists(ethnicity.ID))
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
            return View(ethnicity);
        }

        // GET: EthnicityPOC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ethnicity = await _context.Ethnicities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ethnicity == null)
            {
                return NotFound();
            }

            return View(ethnicity);
        }

        // POST: EthnicityPOC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ethnicity = await _context.Ethnicities.FindAsync(id);
            _context.Ethnicities.Remove(ethnicity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EthnicityExists(int id)
        {
            return _context.Ethnicities.Any(e => e.ID == id);
        }
    }
}
