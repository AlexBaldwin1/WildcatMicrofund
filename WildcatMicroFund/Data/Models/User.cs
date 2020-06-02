using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WildcatMicroFund.Data.Models
{
    public class User
    {
        public int ID { get; set; }
        public UserRole UserRoleID {get; set;}
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Race { get; set;  }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public List<UserBusiness> UserBusinesses { get; set; }
        public List<Application> Applications { get; set; }


    }
}
