using ComiComi.Models;

namespace ComiComi.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);

    }
}
