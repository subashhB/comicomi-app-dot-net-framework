using ComiComi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComiComi.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var order =await _context.Orders.Include(n => n.OrderItems).ThenInclude(n=>n.Comic).Include(n=> n.User).Where(n=>n.UserId == userId).ToListAsync();
            if(userId != "Admin")
            {
                order = order.Where(n => n.UserId == userId).ToList();
            }
            return order;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmail
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ComicId = item.Comic.Id,
                    OrderId = order.Id,
                    Price = item.Comic.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
