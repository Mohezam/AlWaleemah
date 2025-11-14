using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order?> GetWithItemsAndProductsAsync(int orderId);
    }
}
