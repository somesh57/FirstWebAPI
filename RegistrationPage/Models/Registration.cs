using System.ComponentModel.DataAnnotations;

namespace RegistrationPage.Models
{
    public class Registration
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string LatName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public long MobileNumber { get; set; }
    }
}
