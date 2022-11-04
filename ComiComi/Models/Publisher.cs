using ComiComi.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ComiComi.Models
{
    public class Publisher:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Publisher")]
        [Required(ErrorMessage = "Publisher Name is Required!")]
        [StringLength(50, ErrorMessage ="Characters Limit Exceeded!")]
        public string PublisherName { get; set; }

        public List<Comic>? Comics { get; set; }
    }
}
