using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HospitalManagement_BusinessObjects;
using HospitalManagement_Repository;

namespace HospitalManagement_NPPThinh_SE160111.Pages.Accounts
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountRepository _iAccountRepository = null;
        public DeleteModel(IAccountRepository iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }

        [BindProperty]
      public StaffAccount StaffAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _iAccountRepository.GetAccounts() == null)
            {
                return NotFound();
            }

            var staffaccount = _iAccountRepository.GetAccount(id);

            if (staffaccount == null)
            {
                return NotFound();
            }
            else 
            {
                StaffAccount = staffaccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _iAccountRepository.GetAccounts() == null)
            {
                return NotFound();
            }
            var staffaccount = _iAccountRepository.GetAccount(id);

            if (staffaccount != null)
            {
                _iAccountRepository.DeleteAccount(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
