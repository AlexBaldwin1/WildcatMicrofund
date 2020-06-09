using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace WildcatMicroFund.Data.Models
{
    public class Gender
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }
        public User User { get; set; }

        public Gender()
        {

        }
    
    }
}
