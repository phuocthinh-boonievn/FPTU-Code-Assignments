using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HospitalManagement_BusinessObjects;

namespace HospitalManagement_NPPThinh_SE160111.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly HospitalManagement_BusinessObjects.HospitalManagementDBContext _context;

        public IndexModel(HospitalManagement_BusinessObjects.HospitalManagementDBContext context)
        {
            _context = context;
        }

        public IList<DoctorInformation> DoctorInformation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DoctorInformations != null)
            {
                DoctorInformation = await _context.DoctorInformations
                .Include(d => d.Department).ToListAsync();
            }
        }
    }
}
