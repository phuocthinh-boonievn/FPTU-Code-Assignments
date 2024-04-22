using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories
{
    public interface IGlassRepository
    {
        Task<int> GetGlassesCountAsync();
        Task<IList<Eyeglass>> GetGlassesAsync(int pageIndex, int pageSize);
        public Eyeglass GetGlass(int id);

        public List<Eyeglass> GetGlasses();
        public void AddGlass(Eyeglass glass);
        public void DeleteGlass(int id);
    }
}
