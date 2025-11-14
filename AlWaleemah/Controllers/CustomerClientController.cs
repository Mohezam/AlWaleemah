using AlWaleemah.Data;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AlWaleemah.Controllers

{
    public class CustomerClientController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly Applicationdbcontext _context;

        public CustomerClientController(IUnitOfWork unitOfWork, Applicationdbcontext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return View("login");
        }



        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string username, string password)
        {
            var customer = _context.Customers.FirstOrDefault(e => e.Username == username && e.Password == password);



            if (customer != null)
            {
                HttpContext.Session.SetString("UsernameCustomer", customer.Name);
                HttpContext.Session.SetInt32("IdCustomer", customer.Id);
                //HttpContext.Session.SetInt32("CartCount", cartCount);
                return RedirectToAction("Index", "HomePage");

            }

            //if (username == "admin" && password == "123")
            //{

            //    HttpContext.Session.SetString("UsernameCustomer", username);
            //    HttpContext.Session.SetInt32("IdCustomer", 100);
            //    return RedirectToAction("Index", "HomePage");
            //}

            ViewBag.Error = "خطا في اسم المستخدو او كلمة المرور";
            return View();

        }
    }
}
