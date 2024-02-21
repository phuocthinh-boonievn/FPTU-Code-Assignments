using HospitalManagement_BusinessObjects;
using HospitalManagement_Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement_NPPThinh_SE160111.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepository _iAccountRepository = null;
        public LoginModel(IAccountRepository iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            StaffAccount user = _iAccountRepository.GetAccount(username);

            if ((user != null && user.Hrpassword == password) && user.StaffRole == 0)
            {
                return Redirect("/Accounts");
            }

            else if ((user != null && user.Hrpassword == password) && user.StaffRole != 0)
            {
                ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
                return Page();
            }

            else return Page();
        }
    }
}
