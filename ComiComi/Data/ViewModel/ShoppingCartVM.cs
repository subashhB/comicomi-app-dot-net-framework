using ComiComi.Data.Cart;

namespace ComiComi.Data.ViewModel
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public int Volume { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
