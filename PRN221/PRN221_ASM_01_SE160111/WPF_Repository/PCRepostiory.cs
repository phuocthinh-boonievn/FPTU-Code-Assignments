using WPF_DAO;
using WPF_BO;

namespace WPF_Repository
{
    public class PCRepository : IPCRepository
    {
        public Pc GetPC(short id) => PCDAO.Instance.GetPc(id);

        public List<Pc> GetPCs() => PCDAO.Instance.GetPcs();
        public void AddPC(Pc pc) => PCDAO.Instance.AddPC(pc);
        public void UpdatePC(Pc pc) => PCDAO.Instance.UpdatePC(pc);
        public void DeletePC(short id) => PCDAO.Instance.DeletePC(id);
        public List<Pc> SearchPC(string searchValue) => PCDAO.Instance.SearchPC(searchValue);
    }
}