using AlWaleemah.Data;
using AlWaleemah.Dto;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AlWaleemah_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IRepository<Employee> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        // ✅ Get all employees (with DTO)
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employees = _repository.FindAll()
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    Email = e.Email,
                  
                }).ToList();

            return Ok(employees);
        }

        // ✅ Get employee by ID (Route)
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var emp = _repository.FindById(id);
            if (emp == null)
                return NotFound(new { Message = "لا يوجد موظف بهذا الرقم" });

            var dto = new EmployeeDto
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                Email = emp.Email,
            };

            return Ok(dto);
        }

        // ✅ Get employee by ID (Query)
        [HttpGet("GetByIdQuery")]
        public IActionResult GetByIdQuery([FromQuery] int id)
        {
            var emp = _repository.FindById(id);
            if (emp == null)
                return NotFound(new { Message = "لا يوجد موظف بهذا الرقم" });

            var dto = new EmployeeDto
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                Email = emp.Email,
            };

            return Ok(dto);
        }
    }
}
