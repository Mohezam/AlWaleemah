using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Repository

{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly Applicationdbcontext _db;

        public CartItemRepository(Applicationdbcontext db)
        {
            _db = db;
        }

        public Task<List<CartItem>> GetByCustomerWithProductAsync(int customerId)
        {
            return _db.CartItems
                      .Include(c => c.Product)
                      .Where(c => c.CustomerId == customerId)
                      .ToListAsync();
        }

        public void RemoveRange(IEnumerable<CartItem> items)
        {
            _db.CartItems.RemoveRange(items);
        }
    }
}
