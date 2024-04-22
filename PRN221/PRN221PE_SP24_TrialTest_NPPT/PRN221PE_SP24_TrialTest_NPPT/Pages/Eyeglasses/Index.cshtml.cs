using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories;

namespace PRN221PE_SP24_TrialTest_NPPT.Pages.Eyeglasses
{
    public class IndexModel : PageModel
    {
        private readonly IGlassRepository _glassRepository = null;

        public IndexModel(IGlassRepository glassRepository)
        {
            _glassRepository = glassRepository;
        }

        public IList<Eyeglass> Eyeglass { get; private set; }
        public int PageSize { get; private set; } = 4;
        public int TotalPages { get; set; }
        public int PageIndex { get; private set; } = 1;

        public async Task OnGetAsync(int? page)
        {
            int count = await _glassRepository.GetGlassesCountAsync();
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            if (page.HasValue)
            {
                PageIndex = Math.Max(1, Math.Min(page.Value, TotalPages));
            }

            Eyeglass = await _glassRepository.GetGlassesAsync(PageIndex, PageSize);
        }

    }
}
