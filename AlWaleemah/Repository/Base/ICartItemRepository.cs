using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetByCustomerWithProductAsync(int customerId);
        void RemoveRange(IEnumerable<CartItem> items);
    }
}
