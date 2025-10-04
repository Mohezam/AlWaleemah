using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using AlWaleemah.Filters;

namespace AlWaleemah.Controllers
{
    
    [SessionAuthorize]
    public class EmployeesController : Controller
    {
        private readonly Applicationdbcontext _context;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(Applicationdbcontext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var employees = _unitOfWork.Employees.FindAllEmployee();
            if (employees.Any())
            {
                TempData["Sucees"] = "تم جلب البيانات بنجاح";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانات لعرضها";
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            //_context.Employees.Add(employee);
            //_context.SaveChanges();
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Save();
            TempData["Add"] = "تم اضافة البيانات بنجاح";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var cate = _context.Employees.Find(Id);
            var cate = _unitOfWork.Employees.FindById(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Edit(Employee emp)
        {

            //_context.Employees.Update(emp);
            //_context.SaveChanges();

            _unitOfWork.Employees.Update(emp);
            _unitOfWork.Save();
            TempData["Update"] = "تم تعديل البيانات بنجاح";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //var cate = _context.Employees.Find(Id);
            var cate = _unitOfWork.Employees.FindById(Id);

            return View(cate);
        }


        [HttpPost]
        public IActionResult Deletepost(int Id)
        {

            //_context.Employees.Remove(emp);
            //_context.SaveChanges();
            //_unitOfWork.Employees.Delete(emp);
            //_unitOfWork.Save();

            var emp = _unitOfWork.Employees.FindById(Id);
            emp.IsDelete = true;
            emp.UserDelete = HttpContext.Session.GetInt32("Id") ?? 0;
            emp.DeleteDate = DateTime.Now;
            _unitOfWork.Employees.Update(emp);
            _unitOfWork.Save();
            TempData["Remove"] = "تم حذف البيانات بنجاح";
            return RedirectToAction("Index");


        }

        //    // GET: Employees
        //    public async Task<IActionResult> Index()
        //    {
        //        return View(await _context.Employees.ToListAsync());
        //    }

        //    // GET: Employees/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var employee = await _context.Employees
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(employee);
        //    }

        //    // GET: Employees/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Employees/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,DateOfBirth,Address,Position,Salary,HireDate,Notes")] Employee employee)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(employee);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(employee);
        //    }

        //    // GET: Employees/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var employee = await _context.Employees.FindAsync(id);
        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(employee);
        //    }

        //    // POST: Employees/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,DateOfBirth,Address,Position,Salary,HireDate,Notes")] Employee employee)
        //    {
        //        if (id != employee.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(employee);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!EmployeeExists(employee.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(employee);
        //    }

        //    // GET: Employees/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var employee = await _context.Employees
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(employee);
        //    }

        //    // POST: Employees/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var employee = await _context.Employees.FindAsync(id);
        //        if (employee != null)
        //        {
        //            _context.Employees.Remove(employee);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool EmployeeExists(int id)
        //    {
        //        return _context.Employees.Any(e => e.Id == id);
        //    }
        //}
    }
}