using System.ComponentModel.DataAnnotations;

namespace ComiComi.Data.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="E-mail Address is required!")]
        [Display(Name ="E-mail Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
