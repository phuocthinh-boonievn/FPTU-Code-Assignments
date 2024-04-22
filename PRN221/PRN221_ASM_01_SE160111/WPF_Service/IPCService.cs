using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BO;

namespace WPF_Service
{
    public interface IPCService
    {
        public Pc GetPC(short id);
        public List<Pc> GetPCs();
        public void AddPC(Pc pc);
        public void UpdatePC(Pc pc);
        public void DeletePC(short id);

        public List<Pc> SearchPC(string searchValue);
    }
}
