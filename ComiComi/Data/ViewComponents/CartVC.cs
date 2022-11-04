using ComiComi.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ComiComi.Data.ViewComponents
{

    public class CartVC: ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public CartVC(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;   
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            
            return View(items.Count);
        }
    }
}
