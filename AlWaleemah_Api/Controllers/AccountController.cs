using AlWaleemah.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AlWaleemah_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ✅ Login (POST)
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { Message = "اسم المستخدم وكلمة المرور مطلوبان" });
            }

            var emp = _unitOfWork.Employees.Login(request.Username, request.Password);

            if (emp == null)
            {
                return Unauthorized(new { Message = "خطأ في اسم المستخدم أو كلمة المرور" });
            }

            if (emp.Islock)
            {
                return Forbid("تم إغلاق هذا المستخدم، يرجى مراجعة الأدمن");
            }

                // ✅ return user info & role
            return Ok(new
            {
                Message = "تم تسجيل الدخول بنجاح",
                UserId = emp.Id,
                Username = emp.FirstName,
                RoleId = emp.UserRoleId,
                Role = emp.UserRoleId == 1 ? "Admin" : "Employee"
            });
        }

        // ✅ Logout (GET)
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            // هنا ما في Session في API
            // ممكن تخلّيها JWT أو Token Based Authentication
            return Ok(new { Message = "تم تسجيل الخروج بنجاح" });
        }
    }

    // DTO for Login Request
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
