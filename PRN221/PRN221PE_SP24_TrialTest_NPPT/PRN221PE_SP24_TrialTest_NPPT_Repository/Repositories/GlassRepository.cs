using PRN221PE_SP24_TrialTest_NPPT_Repository.DAO;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories
{
    public class GlassRepository : IGlassRepository
    {
        public void AddGlass(Eyeglass glass) => EyeglassesDAO.Instance.AddGlass(glass);
        public void DeleteGlass(int id) => EyeglassesDAO.Instance.DeleteGlass(id);

        public Eyeglass GetGlass(int id) => EyeglassesDAO.Instance.GetGlass(id);

        public List<Eyeglass> GetGlasses() => EyeglassesDAO.Instance.GetGlasses();

        public Task<IList<Eyeglass>> GetGlassesAsync(int pageIndex, int pageSize) => EyeglassesDAO.Instance.GetGlassesAsync(pageIndex, pageSize);

        public Task<int> GetGlassesCountAsync() => EyeglassesDAO.Instance.GetGlassesCountAsync();  
    }
}
