using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Registration1
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LatName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNumber { get; set; }
    }
}
