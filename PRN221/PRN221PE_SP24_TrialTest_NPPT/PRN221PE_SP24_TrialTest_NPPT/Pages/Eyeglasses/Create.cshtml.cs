using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories;

namespace PRN221PE_SP24_TrialTest_NPPT.Pages.Eyeglasses
{
    public class CreateModel : PageModel
    {
        private readonly IGlassRepository _glassRepository = null;

        public CreateModel(IGlassRepository glassRepository)
        {
            _glassRepository = glassRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _glassRepository.GetGlasses() == null || Eyeglass == null)
            {
                return Page();
            }

            _glassRepository.AddGlass(Eyeglass);

            return RedirectToPage("./Index");
        }
    }
}
