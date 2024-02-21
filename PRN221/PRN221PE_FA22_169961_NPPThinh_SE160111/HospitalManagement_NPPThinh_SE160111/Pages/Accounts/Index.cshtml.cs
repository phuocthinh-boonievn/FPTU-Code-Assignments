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
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _iAccountRepository = null;
        public IndexModel(IAccountRepository iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }

        public IList<StaffAccount> StaffAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_iAccountRepository.GetAccounts() != null)
            {
                StaffAccount = _iAccountRepository.GetAccounts();   
            }
        }
    }
}
