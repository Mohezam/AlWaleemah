using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Applicationdbcontext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(Applicationdbcontext context,IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var categories = _unitOfWork.Categories.FindAll();
            return Ok(categories);
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> category = _unitOfWork.Categories.FindAll();
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "تم إنشاء الفئة بنجاح!";
                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = "بيانات غير صالحة. يرجى التحقق من المدخلات.";
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء إنشاء الفئة: {ex.Message}";
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cate = _context.Categories.Find(Id);

            if (cate == null)
            {
                TempData["ErrorMessage"] = "الفئة غير موجودة!";
                return RedirectToAction("Index");
            }

            return View(cate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Categories.Update(category);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "تم تحديث الفئة بنجاح!";
                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = "بيانات غير صالحة. يرجى التحقق من المدخلات.";
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء تحديث الفئة: {ex.Message}";
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cate = _context.Categories.Find(Id);

            if (cate == null)
            {
                TempData["ErrorMessage"] = "الفئة غير موجودة!";
                return RedirectToAction("Index");
            }

            return View(cate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                var category = _context.Categories.Find(Id);

                if (category == null)
                {
                    TempData["ErrorMessage"] = "الفئة غير موجودة!";
                    return RedirectToAction("Index");
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "تم حذف الفئة بنجاح!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"حدث خطأ أثناء حذف الفئة: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}




























//using AlWaleemah.Data;
//using AlWaleemah.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace AlWaleemah.Controllers
//{
//    public class CategoriesController : Controller
//    {

//        private readonly Applicationdbcontext _context;
//        public CategoriesController(Applicationdbcontext context)
//        {
//            _context = context;

//        }

//        [HttpGet]
//        public ActionResult<IEnumerable<Category>> GetAll()
//        {
//            var categories = _context.Categories.ToList();

//            return Ok(categories); // يرجّع JSON
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            IEnumerable<Category> category = _context.Categories.ToList();
//            return View(category);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {

//            return View();
//        }


//        [HttpPost]
//        public IActionResult Create(Category category)
//        {

//            _context.Categories.Add(category);
//            _context.SaveChanges();
//            return RedirectToAction("Index");


//        }



//        [HttpGet]
//        public IActionResult Edit(int Id)
//        {
//            var cate = _context.Categories.Find(Id);

//            return View(cate);
//        }


//        [HttpPost]
//        public IActionResult Edit(Category category)
//        {

//            _context.Categories.Update(category);
//            _context.SaveChanges();
//            return RedirectToAction("Index");


//        }

//        [HttpGet]
//        public IActionResult Delete(int Id)
//        {
//            var cate = _context.Categories.Find(Id);

//            return View(cate);
//        }


//        [HttpPost]
//        public IActionResult Delete(Category category)
//        {

//            _context.Categories.Remove(category);
//            _context.SaveChanges();
//            return RedirectToAction("Index");


//        }
//    }
//}
