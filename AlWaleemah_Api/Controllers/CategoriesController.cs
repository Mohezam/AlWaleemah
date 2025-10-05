using AlWaleemah.Data;
using AlWaleemah.Dto;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AlWaleemah_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        //private readonly Applicationdbcontext _context;
        private readonly IRepository<Category> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IRepository<Category> repository, IUnitOfWork unitOfWork)
        {

            _repository = repository;
            _unitOfWork = unitOfWork;

        }


        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<CategoryDto>> GetAll(int id = 1)
        {
            var categories = _repository.FindAll()
               .Select(c => new CategoryDto
               {
                   Id = c.Id,
                   uid = c.Uid,
                   Name = c.Name,
                   Count = c.Products.Count()
               }).Where(c => c.Id >= id)
                .ToList();

            return Ok(categories); // يرجّع JSON
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCategories2()
        {
            IEnumerable<Category> category = _repository.FindAll();
            return Ok(category);

        }


        [HttpGet("GetById/{Id:int}")]
        public IActionResult GetById(int Id)
        {
            var cate = _repository.FindById(Id);
            if (cate == null)
            {
                return NotFound(new { Message = "لا توجد نتائج لهذا الرقم" });
            }

            return Ok(cate);
        }



        [HttpGet("GetByIdquery")]
        public IActionResult GetByIdquery([FromQuery] int Id)
        {
            var cate = _repository.FindById(Id);
            if (cate == null)
            {
                return NotFound(new { Message = "لا توجد نتائج لهذا الرقم" });
            }

            return Ok(cate);
        }

    }
}
