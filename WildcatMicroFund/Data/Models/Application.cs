using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace WildcatMicroFund.Data.Models
{
    public class Application
    {

        // This model will link the IdeaApplication to the user and business. 
        // This model will also contain the information about the status.
        public int ID { get; set; }
        public Business Business { get; set; }
        public int BusinessID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        [DisplayName("Date of application")]
        public DateTime DateApplied { get; set; }
        [DisplayName("Was a workshop attended")]
        public bool AttendedWorkshop { get; set; }
        [DisplayName("Date of decision")]
        public DateTime DateOfDecision { get; set; }

        public ApplicationApplicationDetail ApplicationApplicationDetail { get; set; }
        public int ApplicationApplicationDetailID { get; set; }

        [DisplayName("Status of application")]
        public string ApplicationStatusID { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }



        

    }
}
