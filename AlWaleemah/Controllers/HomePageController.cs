using AlWaleemah.Data;
using AlWaleemah.Filters;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Controllers
{
    public class HomePageController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly Applicationdbcontext _context;
        public HomePageController(IUnitOfWork unitOfWork , Applicationdbcontext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;

        }



        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Products.FindAllproducts();
            return View(products);
        }

        public IActionResult Details(int Id)
        {
           var products = _unitOfWork.Products.FindByIdproduct(Id);
            return View(products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerSessionAuthorize]
        public IActionResult AddToCart(int id, int custId, int qty = 1)
        {
            var p = _unitOfWork.Products.FindById(id);
            if (p == null) return NotFound();

            var item = new CartItem
            {
                ProductId = p.Id,
                Quantity = qty,
                CustomerId = custId

            };


            _context.CartItems.Add(item);
            _context.SaveChanges();


            return RedirectToAction("Cart");

        }


    }
}
