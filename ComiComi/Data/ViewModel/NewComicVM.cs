using ComiComi.Data.Base;
using ComiComi.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComiComi.Models
{
    public class NewComicVM
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage ="Title is Required")]        
        public string Title { get; set; }

        [Display(Name = "Cover Photo URL")]
        [Required(ErrorMessage = "Cover Photo Path is Required")]
        public string CoverPhotoURL{ get; set; }

        [Display(Name = "Desciption")]
        [Required(ErrorMessage = "Desciption is Required")]
        public string Description { get; set; }

        [Display(Name = "Price per Volume")]
        [Required(ErrorMessage = "Price per Volume")]
        public double Price { get; set; }

        [Display(Name = "Current Volume")]
        [Required(ErrorMessage = "Volume is Required")]
        public int Volume { get; set; }

        [Display(Name = "Comic Status")]
        [Required(ErrorMessage = "Status is Required")]
        public Status Status { get; set; }

        [Display(Name = "Upload Date")]
        [Required(ErrorMessage = "Upload Date is Required")]
        public DateTime UploadDate { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is Required")]
        public Genre Genre { get; set; }

        [Display(Name = "Serialization Type")]
        [Required(ErrorMessage = "Serialization is Required")]
        public Serialization Serializaton { get; set; }

        [Display(Name = "Day of Release")]
        [Required(ErrorMessage = "Release Day is Required")]
        public Day Day { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Author is Required")]
        public int AuthorId { get; set; }

        [Display(Name = "Artist")]
        [Required(ErrorMessage = "Artist is Required")]
        public int ArtistId { get; set; }

        [Display(Name = "Publisher")]
        [Required(ErrorMessage = "Publisher is Required")]
        public int PublisherId { get; set; }

    }
}
