using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;

namespace PRN221PE_SP24_TrialTest_NPPT.Pages.Eyeglasses
{
    public class EditModel : PageModel
    {
        private readonly PRN221PE_SP24_TrialTest_NPPT_Repository.Models.Eyeglasses2024DbContext _context;

        public EditModel(PRN221PE_SP24_TrialTest_NPPT_Repository.Models.Eyeglasses2024DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Eyeglasses == null)
            {
                return NotFound();
            }

            var eyeglass =  await _context.Eyeglasses.FirstOrDefaultAsync(m => m.EyeglassesId == id);
            if (eyeglass == null)
            {
                return NotFound();
            }
            Eyeglass = eyeglass;
           ViewData["LensTypeId"] = new SelectList(_context.LensTypes, "LensTypeId", "LensTypeId");
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

            _context.Attach(Eyeglass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EyeglassExists(Eyeglass.EyeglassesId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EyeglassExists(int id)
        {
          return (_context.Eyeglasses?.Any(e => e.EyeglassesId == id)).GetValueOrDefault();
        }
    }
}
