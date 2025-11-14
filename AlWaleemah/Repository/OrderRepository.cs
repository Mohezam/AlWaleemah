using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Applicationdbcontext _db;
        public OrderRepository(Applicationdbcontext db) => _db = db;

        public async Task AddAsync(Order order) => await _db.Orders.AddAsync(order);

        public Task<Order?> GetWithItemsAndProductsAsync(int orderId) =>
            _db.Orders
               .Include(o => o.Items)
               .ThenInclude(i => i.Product)
               .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}
