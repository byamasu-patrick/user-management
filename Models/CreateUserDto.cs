using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(100), MinLength(8)]
        public string? Password { get; set; }
    }
}
