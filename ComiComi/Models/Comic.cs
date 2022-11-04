using ComiComi.Data.Base;
using ComiComi.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComiComi.Models
{
    public class Comic:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverPhotoURL{ get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Volume { get; set; }
        public Status Status { get; set; }

        public DateTime UploadDate { get; set; }
        public Genre Genre { get; set; }
        public Serialization Serializaton { get; set; }
        public Day Day { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

    }
}
