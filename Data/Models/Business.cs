using System.Collections.Generic;

namespace Data.Models
{
    internal class Business
    {
        
        int ID { get; set; }
        string BusinessName { get; set; }


        public List<UserBusiness> UserBusinesses { get;  set; }
        public List<Application> Applications { get; set; }

    }
}