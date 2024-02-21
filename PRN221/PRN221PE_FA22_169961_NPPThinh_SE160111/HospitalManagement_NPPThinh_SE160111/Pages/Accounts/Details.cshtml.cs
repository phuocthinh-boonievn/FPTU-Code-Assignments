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
    public class DetailsModel : PageModel
    {
        private readonly IAccountRepository _accountRepository = null;
        public DetailsModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public StaffAccount StaffAccount { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _accountRepository.GetAccounts() == null)
            {
                return NotFound();
            }

            var staffaccount = _accountRepository.GetAccount(id);
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
    }
}
