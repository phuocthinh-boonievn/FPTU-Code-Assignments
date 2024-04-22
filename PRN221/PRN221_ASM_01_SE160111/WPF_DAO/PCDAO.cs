using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BO;

namespace WPF_DAO
{
    public class PCDAO
    {
        private static PCDAO instance = null;
        private readonly wpfManagementContext dBContext = null;
        public PCDAO()
        {
            if (dBContext == null)
            {
                dBContext = new wpfManagementContext();
            }
        }
        public static PCDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PCDAO();
                }
                return instance;
            }
        }
        public List<Pc> GetPcs()
        {
            return dBContext.Pcs.ToList();
        }
        public Pc GetPc(short id)
        {
            return dBContext.Pcs.FirstOrDefault(m => m.ProductId.Equals(id));
        }

        public void AddPC(Pc pc)
        {
            Pc existingPC = GetPc(pc.ProductId);
            if (existingPC == null)
            {
                dBContext.Pcs.Add(pc);  
                dBContext.SaveChanges();
            }
        }

        public void UpdatePC(Pc pc)
        {
            if (pc != null)
            {
                dBContext.Pcs.Update(pc);
                dBContext.SaveChanges();
            }
        }
        public void DeletePC(short id)
        {
            Pc pc = GetPc(id);
            if (pc != null)
            {
                var entityEntry = dBContext.Entry(pc);
                if (entityEntry.State == EntityState.Detached)
                {
                    dBContext.Attach(pc);
                }

                dBContext.Remove(pc);
                dBContext.SaveChanges();
            }
        }
        public List<Pc> SearchPC(string searchValue)
        {
            return dBContext.Pcs.Where(p => p.Title.Contains(searchValue)).ToList();
        }

    }
}
