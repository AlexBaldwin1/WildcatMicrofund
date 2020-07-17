using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace WildcatMicroFund.Data.Models
{
    public class Application
    {

        // This model will link the Application and ApplicationDetails to the user and business. 
        // This model will also contain the information about the status.
        public int ID { get; set; }
        
        [AllowNull]
        public Business Business { get; set; }
        public int? BusinessID { get; set; }

        // The user that created the application
        [AllowNull]
        public int? UserID { get; set; }
        [AllowNull]
        public User User { get; set; }


        // Date the application was started
        [DisplayName("Date of application")]
        public DateTime DateApplied { get; set; }
        [DisplayName("Was a workshop attended")]
        public bool AttendedWorkshop { get; set; }
        [DisplayName("Date of decision")]

        public DateTime? DateOfDecision { get; set; }

        public List<ApplicationDetail> ApplicationDetails { get; set; }

        [DisplayName("Status of application")]
        public string ApplicationStatusID { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }



        

    }
}
