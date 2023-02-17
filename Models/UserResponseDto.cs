using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

    }
}
