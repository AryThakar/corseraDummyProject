using System.ComponentModel.DataAnnotations;

namespace MyUserApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int Age { get; set; }
    }
}
