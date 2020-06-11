using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WildcatMicroFund.Data.Models
{
    public class User
    {
        public int ID { get; set; }
        public List<UserRole> UserRoles {get; set;}
        
        [Required]
        [Column(TypeName = "varchar(400)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column (TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PhoneNumber { get; set; }

        
        public int GenderID { get; set; }
        public Gender Gender { get; set; }
        

        public int EthnicityID { get; set; }
        public Ethnicity Ethnicity { get; set; }


        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public List<UserBusiness> UserBusinesses { get; set; }
        public List<Application> Applications { get; set; }


    }
}
