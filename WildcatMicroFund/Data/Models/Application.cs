using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicroFund.Data.Models
{
    public class Application
    {
        public int ID { get; set; }
        public Business Business { get; set; }
        public int BusinessID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime DateApplied { get; set; }
        public bool AttendedWorkshop { get; set; }
        public DateTime DateOfDecision { get; set; }
        public Survey Survey { get; set; }
        public int SurveyID { get; set; }
         
        //TODO a table for statuses
        public string ApplicationStatus { get; set; }

        

    }
}
