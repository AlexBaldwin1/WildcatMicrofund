using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WildcatMicroFund.Data.Context;
using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.Controllers
{
    public class SurveyPOC : Controller
    {
        private readonly WildcatMicroFundDatabaseContext _context;

        public SurveyPOC(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }

        // GET: SurveyPOC
        public async Task<IActionResult> Index()
        {
            var wildcatMicroFundDatabaseContext = _context.SurveyCodes;
            return View(await wildcatMicroFundDatabaseContext.ToListAsync());
        }

        //GET: SurveyPOC/TakeSurvey/ID
        public async Task<IActionResult> TakeSurvey(int id)
        {
            var surveyContents = _context.SurveyCodes
                .Include(sc => sc.Questions)
                .ThenInclude(q => q.QuestionType)
                .Include(sc => sc.Questions)
                .ThenInclude(q => q.Choices)
                .Where(sc => sc.ID == id);

            return View(await surveyContents.FirstOrDefaultAsync<SurveyCode>());
        }
    }
}
