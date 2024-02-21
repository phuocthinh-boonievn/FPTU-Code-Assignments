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
    public class DetailsModel : PageModel
    {
        private readonly HospitalManagement_BusinessObjects.HospitalManagementDBContext _context;

        public DetailsModel(HospitalManagement_BusinessObjects.HospitalManagementDBContext context)
        {
            _context = context;
        }

      public DoctorInformation DoctorInformation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.DoctorInformations == null)
            {
                return NotFound();
            }

            var doctorinformation = await _context.DoctorInformations.FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorinformation == null)
            {
                return NotFound();
            }
            else 
            {
                DoctorInformation = doctorinformation;
            }
            return Page();
        }
    }
}
