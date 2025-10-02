using AlWaleemah.Data;
using AlWaleemah.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Controllers
{
    public class ProductQuantityViewController : Controller
    {
        private readonly Applicationdbcontext _context;
        public ProductQuantityViewController(Applicationdbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();

            var query = _context.Products.Include(p => p.Category).AsQueryable();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            var stockList = await query
                .Select(p => new ProductQuantityView
                {
                    CategoryName = p.Category.Name,
                    ProductName = p.ProductName,
                    Quantity = p.Quantity,
                    ImageUrl = p.ImageUrl
                })
                .ToListAsync();

            return View(stockList);
        }
    }
}

