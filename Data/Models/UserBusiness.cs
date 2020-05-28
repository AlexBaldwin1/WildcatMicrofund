using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    class UserBusiness
    {
        //int ID { get; set; }
        public int BusinessID { get; set; }
        public Business Business { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        
    }
}
