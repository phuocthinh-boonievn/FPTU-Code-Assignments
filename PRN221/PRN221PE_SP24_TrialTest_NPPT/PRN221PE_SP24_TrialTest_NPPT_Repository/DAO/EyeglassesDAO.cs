using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221PE_SP24_TrialTest_NPPT_Repository.DAO
{
    public class EyeglassesDAO
    {
        private static EyeglassesDAO instance = null;
        private readonly Eyeglasses2024DbContext dBContext = null;
        public EyeglassesDAO()
        {
            if (dBContext == null)
            {
                dBContext = new Eyeglasses2024DbContext();
            }
        }
        public static EyeglassesDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EyeglassesDAO();
                }
                return instance;
            }
        }

        public Eyeglass GetGlass(int id)
        {
            return dBContext.Eyeglasses.FirstOrDefault(m => m.EyeglassesId.Equals(id));
        }

        public List<Eyeglass> GetGlasses()
        {
            return dBContext.Eyeglasses.ToList();
        }

        public async Task<int> GetGlassesCountAsync()
        {
            return await dBContext.Eyeglasses.CountAsync();
        }

        public async Task<IList<Eyeglass>> GetGlassesAsync(int pageIndex, int pageSize)
        {
            return await dBContext.Eyeglasses
                .OrderBy(e => e.EyeglassesId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public void AddGlass(Eyeglass glass)
        {
            Eyeglass newGlass = GetGlass(glass.EyeglassesId);
            if (newGlass == null)
            {
                dBContext.Eyeglasses.Add(newGlass);
                dBContext.SaveChanges();
            }
        }

        //public async void UpdateGlass(Eyeglass glass)
        //{
        //    StaffAccount staff = GetAccount(account.HraccountId);
        //    if (staff != null)
        //    {
        //        dBContext.Attach(account).State = EntityState.Modified;
        //        await dBContext.SaveChangesAsync();
        //    }
        //}
        public void DeleteGlass(int id)
        {
            Eyeglass glass = GetGlass(id);
            if (glass != null)
            {
                dBContext.Eyeglasses.Remove(glass);
                dBContext.SaveChanges();
            }
        }

    }
}
