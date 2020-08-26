using System;
using System.Collections.Generic;
using System.Text;

namespace WildcatMicroFund.Data.Models
{
    public class UserBusiness
    {
        public int ID { get; set; }
        public int BusinessID { get; set; }
        public Business Business { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        
    }
}
