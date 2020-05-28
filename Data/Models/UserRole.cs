namespace Data.Models
{
    internal class UserRole
    {
        public int ID { get; set; }
        public string RoleDescription { get; set; }
        public User User { get; set; }
        
    }
}