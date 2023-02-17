namespace UserManagement.Entities
{
    public class User
    {
        public string FirstName { get; set; } = string.Empty.ToString();
        public string LastName { get; set; } = string.Empty.ToString(); 
        public string Email { get; set; } = string.Empty.ToString();
        public string PasswordHash { get; set; } = string.Empty.ToString();
        public string Salt { get; set;  } = string.Empty.ToString();
        public string RefreshToken { get; set;} = string.Empty.ToString();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

    }
}
