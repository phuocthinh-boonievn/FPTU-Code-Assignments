using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HospitalManagement_BusinessObjects;
using HospitalManagement_Repository;

namespace HospitalManagement_NPPThinh_SE160111.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository _accountRepository = null;
        public CreateModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StaffAccount StaffAccount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _accountRepository.GetAccounts() == null || StaffAccount == null)
            {
                return Page();
            }

            _accountRepository.AddAccount(StaffAccount);

            return RedirectToPage("./Index");
        }
    }
}
