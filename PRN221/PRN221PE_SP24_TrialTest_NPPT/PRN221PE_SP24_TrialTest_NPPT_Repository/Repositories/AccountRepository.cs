using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;
using PRN221PE_SP24_TrialTest_NPPT_Repository.DAO;

namespace PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public StoreAccount GetAccount(string id) => AccountDAO.Instance.GetAccount(id);

        public List<StoreAccount> GetAccounts() => AccountDAO.Instance.GetAccounts();
    }
}

