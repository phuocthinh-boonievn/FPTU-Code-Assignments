using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories;

namespace PRN221PE_SP24_TrialTest_NPPT.Pages
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
            StoreAccount user = _iAccountRepository.GetAccount(username);

            if ((user != null && user.AccountPassword == password) && (user.Role == 1 || user.Role == 2 ))
            {
                return Redirect("/Eyeglasses");
            }

            else if ((user != null && user.AccountPassword == password) && !(user.Role == 1 || user.Role == 2))
            {
                ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
                return Page();
            }

            else return Page();
        }
    }
}
