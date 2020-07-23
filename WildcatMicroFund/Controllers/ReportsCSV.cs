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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildcatMicroFund.Controllers
{

    public class ReportsCSV : Controller
    {

        private readonly WildcatMicroFundDatabaseContext _context;

        public ReportsCSV(WildcatMicroFundDatabaseContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public FileResult ExportUsers()
        {
            var wildcatMicroFundDatabaseContext = _context.Users
                .Include(u => u.Ethnicity)
                .Include(u => u.Gender)
                .Include(u => u.UserBusinesses).ThenInclude(ub => ub.Business)
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

        [HttpPost]
        public FileResult ExportAllApplications()
        {
            var wildcatMicroFundDatabaseContext = _context.Applications
                .Include(i => i.User)
                .Include(i => i.ApplicationStatus)
                .Include(i => i.ApplicationDetails);
                


            List<Application> Applications = wildcatMicroFundDatabaseContext.ToList();




            //Insert the Column Names.


            StringBuilder sb = new StringBuilder();

            sb.Append("ID, First Name, Last Name, Ethicity, Gender, Costs, Marketing, Idea Description ");
            sb.Append("\r\n");

            for (int i = 0; i < Applications.Count; i++)
            {

                //Append data with separator.

                sb.Append(Applications[i].ID.ToString() + ',');
                


                if (Applications[i].User != null)
                {
                    sb.Append(Applications[i].User.FirstName + ',');
                    sb.Append(Applications[i].User.LastName + ',');
                    sb.Append(Applications[i].User.Ethnicity.EthnicityDescription + ',');
                    sb.Append(Applications[i].User.Gender.Description + ',');
                }
                else
                {
                    sb.Append("null ,");
                    sb.Append("null ,");
                    sb.Append("null ,");
                    sb.Append("null ,");

                }

                ApplicationDetail lastAppDetail = Applications[i].ApplicationDetails.Last();

                
                sb.Append(lastAppDetail.BusinessCosts + ',');
                sb.Append(lastAppDetail.MarketingAndSales + ',');
                sb.Append(lastAppDetail.BusinessIdeaDescription + ',');


                //Append new line character.
                sb.Append("\r\n");

            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }

    }
}
