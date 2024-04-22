using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Equipments_NPPThinh.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("CurrentUser");
            HttpContext.Session.Remove("FullName");
            HttpContext.Session.Remove("Type");

            return RedirectToPage("/Index");
        }
    }
}
