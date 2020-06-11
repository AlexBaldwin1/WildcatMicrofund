using System.Collections.Generic;

namespace WildcatMicroFund.Data.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleDescription { get; set; }
        public List<UserRole> UserRoles { get; set; }
        
    }
}