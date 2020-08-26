using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildcatMicroFund.Data.Models
{
    public class Ethnicity
    {
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EthnicityDescription { get; set; }
        public List<User> Users { get; set; }
    }
}
