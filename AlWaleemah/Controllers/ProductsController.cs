using AlWaleemah.Data;
using AlWaleemah.Filters;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlWaleemah.Controllers
{
    [SessionAuthorize]
    public class ProductsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //public ProductsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //   private readonly IRepository<Product> _repository;  


        //private readonly IRepository<Category> _repositoryCategory;
        //private readonly IRepoProduct _repoProduct;

        //public ProductsController( IRepository<Category> repositoryCategory , IRepoProduct repoProduct)
        //{

        //    _repositoryCategory = repositoryCategory;
        //    _repoProduct = repoProduct;
        //}


        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public ProductsController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }





        //public IActionResult Index()
        //{
        //    IEnumerable<Product> products = _context.Products.Include(e => e.Category).ToList();
        //    return View(products);
        //}

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Products.FindAllproducts();
            return View(products);
        }


        //public IActionResult Index()
        //{
        //    IEnumerable<Product> products = _repository.FindAll();
        //    return View(products);
        //}


        //public IActionResult GetAll2()
        //{
        //    IEnumerable<Product> products = _context.Products.Include(e=>e.Category).AsNoTracking().ToList();
        //    return Ok(products);
        //}



        //public IActionResult GetAll()
        //{
        //    IEnumerable<ProductDto> products =
        //        _context.Products.
        //        Include(e => e.Category)
        //        .AsNoTracking()
        //        .Select(p => new ProductDto
        //        {
        //            Id = p.Id,
        //            ProductName = p.ProductName,
        //            Price = p.Price,
        //            CategoryId = p.CategoryId,
        //            CategoryName = p.Category.Name
        //        })
        //        .ToList();
        //    return Ok(products);
        //}





        private void CreateCategorySelectList()
        {
            // List<CategoryDto> categories = new List<CategoryDto> {

            //// new CategoryDto { Id = 0, Name = "Select Category" } ,
            //     new CategoryDto { Id = 1, Name = "Electronics" } ,
            //     new CategoryDto { Id = 2, Name = "Clothing" } ,
            //     new CategoryDto { Id = 3, Name = "Mobiles" } ,
            // };


            IEnumerable<Category> categories = _unitOfWork.Categories.FindAll();

            SelectList selectListItems = new SelectList(categories, "Id", "Name", 0);
            ViewBag.Categories = selectListItems;

        }



        private string? SaveImage(IFormFile? file)
        {
            if (file == null || file.Length == 0) return null;

            // التحقق من الامتداد (اختياري لكنه مهم)
            var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowed.Contains(ext))
                throw new InvalidOperationException("امتداد الملف غير مسموح");

            // مسار المجلد داخل wwwroot
            var folder = Path.Combine("uploads", "products");
            var rootFolder = Path.Combine(_env.WebRootPath, folder);

            // إنشاء المجلد لو غير موجود
            Directory.CreateDirectory(rootFolder);

            // اسم ملف فريد
            var fileName = $"{Guid.NewGuid():N}{ext}";
            var fullPath = Path.Combine(rootFolder, fileName);

            using (var stream = System.IO.File.Create(fullPath))
            {
                file.CopyTo(stream);
            }

            // نعيد المسار النسبي للاستخدام في <img src="~/{path}">
            var relativePath = Path.Combine(folder, fileName).Replace('\\', '/');
            return "/" + relativePath;
        }



        private void DeleteImageIfExists(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return;

            var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {

            CreateCategorySelectList();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Product ptoducts)
        {
            if (ModelState.IsValid)
            {



                if (ptoducts.ImageFile != null)
                {




                    // حفظ الصورة في المجلد وإرجاع المسار النسبي
                    var imagePath = SaveImage(ptoducts.ImageFile);
                    ptoducts.ImageUrl = imagePath;


                }

                _unitOfWork.Products.Add(ptoducts);
                _unitOfWork.Save();

                TempData["Add"] = "تم اضافة البيانات بنجاح";
                return RedirectToAction("Index");

            }

            else
            {
                return View(ptoducts);
            }


        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var cate = _context.Products.Find(Id);
            var cate = _unitOfWork.Products.FindById(Id);

            CreateCategorySelectList();

            return View(cate);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {

            //_context.Products.Update(product);
            //_context.SaveChanges();
            var exist = _unitOfWork.Products.FindByIdproduct(product.Id);

            if (product.ImageFile != null)
            {


                // حذف الصورة القديمة إذا كانت موجودة
                DeleteImageIfExists(exist.ImageUrl);

                // حفظ الصورة في المجلد وإرجاع المسار النسبي
                var imagePath = SaveImage(product.ImageFile);
                product.ImageUrl = imagePath;


            }

            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
            TempData["Update"] = "تم تحديث البيانات بنجاح";
            return RedirectToAction("Index");


        }




    }
}
//namespace AlWaleemah.Controllers
//{
//    [SessionAuthorize]
//    public class ProductsController : Controller
//    {
//        //private readonly Applicationdbcontext _context;
//        private readonly IWebHostEnvironment _env;
//        private readonly IUnitOfWork _unitOfWork;



//        public ProductsController( IWebHostEnvironment env, IUnitOfWork unitOfWork)
//        {
//            //_context = context;
//            _env = env;
//            _unitOfWork = unitOfWork;

//        }

//        // GET: Products
//        //public async Task<IActionResult> Index()
//        //{
//        //    return View(await _context.Products.ToListAsync());
//        //}
//        public IActionResult Index()
//        {
//            var products = _unitOfWork.Products.FindAllproducts().ToList();
//            return View(products);
//        }
//        private void CreateCategorySelectList()
//        {
//            // List<CategoryDto> categories = new List<CategoryDto> {

//            //// new CategoryDto { Id = 0, Name = "Select Category" } ,
//            //     new CategoryDto { Id = 1, Name = "Electronics" } ,
//            //     new CategoryDto { Id = 2, Name = "Clothing" } ,
//            //     new CategoryDto { Id = 3, Name = "Mobiles" } ,
//            // };


//            IEnumerable<Category> categories = _unitOfWork.Categories.FindAll();

//            SelectList selectListItems = new SelectList(categories, "Id", "Name", 0);
//            ViewBag.Categories = selectListItems;

//        }


//        // GET: Products/Details/5
//        //public async Task<IActionResult> Details(int? id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var product = await _context.Products
//        //        .FirstOrDefaultAsync(m => m.Id == id);
//        //    if (product == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(product);
//        //}

//        // GET: Products/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Products/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Create([Bind("Id,ProductName,Price,Categorys,Quantity,Description")] Product product)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _context.Add(product);
//        //        await _context.SaveChangesAsync();
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    return View(product);
//        //}


//        private string? SaveImage(IFormFile? file)
//        {
//            if (file == null || file.Length == 0) return null;

//            // التحقق من الامتداد (اختياري لكنه مهم)
//            var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
//            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
//            if (!allowed.Contains(ext))
//                throw new InvalidOperationException("امتداد الملف غير مسموح");

//            // مسار المجلد داخل wwwroot
//            var folder = Path.Combine("uploads", "products");
//            var rootFolder = Path.Combine(_env.WebRootPath, folder);

//            // إنشاء المجلد لو غير موجود
//            Directory.CreateDirectory(rootFolder);

//            // اسم ملف فريد
//            var fileName = $"{Guid.NewGuid():N}{ext}";
//            var fullPath = Path.Combine(rootFolder, fileName);

//            using (var stream = System.IO.File.Create(fullPath))
//            {
//                file.CopyTo(stream);
//            }

//            // نعيد المسار النسبي للاستخدام في <img src="~/{path}">
//            var relativePath = Path.Combine(folder, fileName).Replace('\\', '/');
//            return "/" + relativePath;
//        }



//        private void DeleteImageIfExists(string? relativePath)
//        {
//            if (string.IsNullOrWhiteSpace(relativePath)) return;

//            var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
//            if (System.IO.File.Exists(fullPath))
//            {
//                System.IO.File.Delete(fullPath);
//            }
//        }


//        [HttpPost]
//        public IActionResult Create(Product ptoducts)
//        {
//            if (ModelState.IsValid)
//            {

//                //_context.Products.Add(ptoducts);
//                //_context.SaveChanges();


//                if (ptoducts.ImageFile != null)
//                {

//                    // حفظ الصورة في المجلد وإرجاع المسار النسبي
//                    var imagePath = SaveImage(ptoducts.ImageFile);
//                    ptoducts.ImageUrl = imagePath;

//                }

//                _unitOfWork.Products.Add(ptoducts);
//                _unitOfWork.Save();
//                //_context.Products.Add(ptoducts);
//                //_context.SaveChanges();

//                TempData["Add"] = "تم اضافة البيانات بنجاح";
//                return RedirectToAction("Index");

//            }

//            else
//            {
//                return View(ptoducts);
//            }


//        }

//        // GET: Products/Edit/5
//        public IActionResult Edit(int id)
//        {
//            var product = _unitOfWork.Products.FindById(id);
//            if (product == null)
//                return NotFound();

//            CreateCategorySelectList();
//            return View(product);
//        }


//        // POST: Products/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

//        [HttpPost]
//        public IActionResult Edit(Product product)
//        {

//            //_context.Products.Update(product);
//            //_context.SaveChanges();
//            var exist = _unitOfWork.Products.FindByIdproduct(product.Id);

//            if (product.ImageFile != null)
//            {


//                // حذف الصورة القديمة إذا كانت موجودة
//                DeleteImageIfExists(exist.ImageUrl);

//                // حفظ الصورة في المجلد وإرجاع المسار النسبي
//                var imagePath = SaveImage(product.ImageFile);
//                product.ImageUrl = imagePath;


//            }

//            _unitOfWork.Products.Update(product);
//            _unitOfWork.Save();
//            TempData["Update"] = "تم تحديث البيانات بنجاح";
//            return RedirectToAction("Index");


//        }



//        // GET: Products/Delete/5
//        public IActionResult Delete(int id)
//        {
//            var product = _unitOfWork.Products.FindById(id);
//            if (product == null)
//                return NotFound();

//            return View(product);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var product = _unitOfWork.Products.FindById(id);
//            if (product != null)
//            {
//                _unitOfWork.Products.Delete(product);
//                _unitOfWork.Save();
//            }

//            return RedirectToAction(nameof(Index));
//        }


//        //private bool ProductExists(int id)
//        //{
//        //    return _context.Products.Any(e => e.Id == id);
//        //}
//    }
//}
