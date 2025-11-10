using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Controllers
{
    public class UtilitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UtilitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Utilities
        public IActionResult Index()
        {
            var utilities = _unitOfWork.Utilities.GetActiveUtilities();
            return View(utilities);
        }

        // GET: Utilities/Details/5
        public IActionResult Details(int id)
        {
            var utility = _unitOfWork.Utilities.FindById(id);
            if (utility == null)
            {
                return NotFound();
            }
            return View(utility);
        }

        // GET: Utilities/Create
        public IActionResult Create()
        {
            PrepareViewData();
            return View();
        }

        // POST: Utilities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Utility utility)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Utilities.Add(utility);
                _unitOfWork.Save();

                TempData["Success"] = "تم إضافة الأداة بنجاح";
                return RedirectToAction(nameof(Index));
            }

            PrepareViewData();
            return View(utility);
        }

        // GET: Utilities/Edit/5
        public IActionResult Edit(int id)
        {
            var utility = _unitOfWork.Utilities.FindById(id);
            if (utility == null)
            {
                return NotFound();
            }

            PrepareViewData();
            return View(utility);
        }

        // POST: Utilities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Utility utility)
        {
            if (id != utility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                utility.UpdatedAt = DateTime.Now;
                _unitOfWork.Utilities.Update(utility);
                _unitOfWork.Save();

                TempData["Success"] = "تم تحديث الأداة بنجاح";
                return RedirectToAction(nameof(Index));
            }

            PrepareViewData();
            return View(utility);
        }

        // GET: Utilities/Delete/5
        public IActionResult Delete(int id)
        {
            var utility = _unitOfWork.Utilities.FindById(id);
            if (utility == null)
            {
                return NotFound();
            }
            return View(utility);
        }

        // POST: Utilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var utility = _unitOfWork.Utilities.FindById(id);
            if (utility != null)
            {
                utility.IsActive = false;
                utility.UpdatedAt = DateTime.Now;
                _unitOfWork.Utilities.Update(utility);
                _unitOfWork.Save();

                TempData["Success"] = "تم حذف الأداة بنجاح";
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Utilities/ByType/Color
        public IActionResult ByType(UtilityType type)
        {
            var utilities = _unitOfWork.Utilities.GetByType(type);
            ViewBag.UtilityType = type;
            return View(utilities);
        }

        private void PrepareViewData()
        {
            // تعبئة قائمة الأنواع
            ViewBag.UtilityTypes = new SelectList(Enum.GetValues(typeof(UtilityType))
                .Cast<UtilityType>()
                .Select(e => new { Value = e, Text = e.GetDisplayName() }),
                "Value", "Text");

            // تعبئة قائمة الفئات
            var categories = _unitOfWork.Utilities.GetCategories().ToList();
            ViewBag.Categories = new SelectList(categories);
        }
    }

    // Extension method للحصول على Display Name للـ Enum
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;
            return attribute?.Name ?? value.ToString();
        }


    }
}
