using System.Collections.Generic;

namespace WildcatMicroFund.Data.Models
{
    public class Business
    {
        
        public int ID { get; set; }
        public string BusinessName { get; set; }


        public List<UserBusiness> UserBusinesses { get;  set; }
        public List<Application> Applications { get; set; }

    }
}