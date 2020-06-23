using System.Collections.Generic;

namespace WildcatMicroFund.Data.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }        
    }
}