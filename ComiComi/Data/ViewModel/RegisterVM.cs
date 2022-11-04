using System.ComponentModel.DataAnnotations;

namespace ComiComi.Data.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Full Name is required!")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="E-mail Address is required!")]
        [Display(Name ="E-mail Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Entered do not match")]
        public string ConfirmPassword { get; set; }
    }
}
