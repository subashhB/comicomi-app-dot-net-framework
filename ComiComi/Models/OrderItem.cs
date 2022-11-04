using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComiComi.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Volume { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        [ForeignKey("ComicId")]
        public Comic Comic { get; set; }
        public int ComicId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
