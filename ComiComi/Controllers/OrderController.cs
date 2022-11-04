using ComiComi.Data.Cart;
using ComiComi.Data.Services;
using ComiComi.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ComiComi.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IComicService _comicService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderService;

        public OrderController(IComicService comicService, ShoppingCart shoppingCart, IOrderService orderService)
        {
            _comicService = comicService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
        }
        
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _orderService.GetOrderByUserIdAndRoleAsync(userId,userRole);
            return View(orders);

        }

        
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        
        public async Task<IActionResult> AddItemToShoppingCart(int id, int volume)
        {
            var item = await _comicService.GetComicByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item, volume);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _comicService.GetComicByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
