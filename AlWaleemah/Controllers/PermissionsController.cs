using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlWaleemah.Controllers
{
    public class PermissionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        private void CreateEmployeeSelectList()
        {
            IEnumerable<Employee> emp = _unitOfWork.Employees.FindAll();

            SelectList selectListItems = new SelectList(emp, "Id", "FirstName", 0);
            ViewBag.Emp = selectListItems;

        }



        public IActionResult Index()
        {
            var permissions = _unitOfWork.Permission.FindAll();
            return View(permissions);

        }

        public IActionResult Create()
        {
            CreateEmployeeSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Permission permission)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Permission.Add(permission);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ////CreateEmployeeSelectList(permission.EmployeeId);
            return View();
        }
        public IActionResult Edit()
        {
            //CreateEmployeeSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Permission permission)
        {
            return View();
        }

    } 
}
