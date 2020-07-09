using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace WildcatMicroFund.Data.Models
{
    public class Business
    {
        
        public int ID { get; set; }
        public string BusinessName { get; set; }


        public List<UserBusiness> UserBusinesses { get;  set; }
        public List<Application> Applications { get; set; }

        [DisplayName("Mentor")]
        public User Mentor { get; set; }
        public int? MentorID { get; set; }

    }
}