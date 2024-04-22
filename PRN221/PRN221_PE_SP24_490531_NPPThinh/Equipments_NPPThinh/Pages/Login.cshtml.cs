using Equipments_Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Equipments_NPPThinh.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public LoginModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // DTO không hợp lệ, có lỗi xảy ra
                return Page();
            }

            var user = _unitOfWork.AccountRepository.Get(u => u.Email == Username && u.Password == Password && u.RoleId == 1 || u.Email == Username && u.Password == Password && u.RoleId == 2).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("CurrentUser", user.UserName); // Lưu thông tin người dùng vào phiên làm việc
                HttpContext.Session.SetString("FullName", user.FullName);
                HttpContext.Session.SetString("Type", user.RoleId.ToString());

                return RedirectToPage("/Index");
            }
            else
            {
                // Đăng nhập không thành công, hiển thị thông báo lỗi
                ViewData["ErrorMessage"] = "You do not have permission to do this function!";
                return Page();
            }
        }
    }
}
