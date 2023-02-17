namespace UserManagement.Entities
{
    public class User
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } 
        public byte[] Salt { get; set;  }
        public string RefreshToken { get; set;} 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

    }
}
