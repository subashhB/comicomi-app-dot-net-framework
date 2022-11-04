using System.ComponentModel.DataAnnotations;

namespace ComiComi.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Comic Comic { get; set; }
        public int Amount { get; set; }
        public int Volume { get; set; }
        public string ShoppingCartId { get; set; }  
    }
}
