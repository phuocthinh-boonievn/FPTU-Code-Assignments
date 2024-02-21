using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagement_BusinessObjects;
using HospitalManagement_Repository;

namespace HospitalManagement_NPPThinh_SE160111.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountRepository _iAccountRepository = null;

        public EditModel(IAccountRepository iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }


        [BindProperty]
        public StaffAccount StaffAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _iAccountRepository.GetAccounts == null)
            {
                return NotFound();
            }

            var staffaccount = _iAccountRepository.GetAccount(id);
            if (staffaccount == null)
            {
                return NotFound();
            }
            StaffAccount = staffaccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _iAccountRepository.UpdateAccount(StaffAccount);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
