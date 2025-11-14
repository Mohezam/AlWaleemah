using AlWaleemah.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp2_AspMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Applicationdbcontext _db;

        public OrdersController(Applicationdbcontext db)
        {
            _db = db;
        }

        public IActionResult Details(int id)
        {
            var order = _db.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        public IActionResult CustomerOrders(int customerId)
        {
            var orders = _db.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.CustomerId == customerId)
                .ToList();

            if (!orders.Any())
                return NotFound("لا توجد طلبات لهذا العميل");

            return View(orders);
        }


    }

}
