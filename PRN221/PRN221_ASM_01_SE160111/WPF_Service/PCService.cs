using WPF_Repository;
using WPF_BO;

namespace WPF_Service
{
    public class PCService : IPCService
    {
        private readonly IPCRepository pcRepository = null;
        public PCService()
        {
            pcRepository = new PCRepository();
        }

        public void AddPC(Pc pc)
        {
            pcRepository.AddPC(pc);
        }
        public void UpdatePC(Pc pc)
        {
            pcRepository.UpdatePC(pc);
        }
        public void DeletePC(short id)
        {
            pcRepository.DeletePC(id);
        }

        public Pc GetPC(short id)
        {
            return pcRepository.GetPC(id);
        }

        public List<Pc> GetPCs()
        {
            return pcRepository.GetPCs();
        }
        public List<Pc> SearchPC(string searchValue)
        {
            return pcRepository.SearchPC(searchValue);
        }
    }
}