using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories;

namespace PRN221PE_SP24_TrialTest_NPPT.Pages.Eyeglasses
{
    public class DeleteModel : PageModel
    {
        private readonly IGlassRepository _glassRepository = null;

        public DeleteModel(IGlassRepository glassRepository)
        {
            _glassRepository = glassRepository;
        }


        [BindProperty]
      public Eyeglass Eyeglass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _glassRepository.GetGlasses() == null)
            {
                return NotFound();
            }

            var eyeglass = _glassRepository.GetGlass((int)id);
            if (eyeglass == null)
            {
                return NotFound();
            }
            else 
            {
                Eyeglass = eyeglass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _glassRepository.GetGlasses() == null)
            {
                return NotFound();
            }
            var eyeglass = _glassRepository.GetGlass((int)id);

            if (eyeglass != null)
            {
                _glassRepository.DeleteGlass((int) id);
            }

            return RedirectToPage("./Index");
        }
    }
}
