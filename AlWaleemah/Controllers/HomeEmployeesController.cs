using Microsoft.AspNetCore.Mvc;

namespace AlWaleemah.Controllers
{
    public class HomeEmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
