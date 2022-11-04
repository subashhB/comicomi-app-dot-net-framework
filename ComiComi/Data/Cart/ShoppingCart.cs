using ComiComi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComiComi.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();
            session.SetString("Id", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public void AddItemToCart(Comic comic, int volume)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Comic.Id == comic.Id && n.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Comic = comic,
                    Amount = 1,
                    Volume = volume,
                }; 
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void EditVolume(Comic comic,int volume)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Comic.Id == comic.Id && n.ShoppingCartId == ShoppingCartId);
            if(comic.Volume >= volume)
            {
                shoppingCartItem.Volume = volume;
            }
            _context.SaveChanges();
            
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Comic comic)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Comic.Id == comic.Id &&
            n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }            
            _context.SaveChanges();

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Comic).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Comic.Price * n.Amount).Sum();
        
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

    }

}
