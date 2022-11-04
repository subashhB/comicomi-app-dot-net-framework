using ComiComi.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ComiComi.Models
{
    public class Artist: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage ="Name is Required")]
        public string ArtistName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Bio is Required!")]
        [StringLength(2000, ErrorMessage = "Characters Limit Exceeded")]
        public string Bio { get; set; }

        public List<Comic>? Comics { get; set; }

    }
}
