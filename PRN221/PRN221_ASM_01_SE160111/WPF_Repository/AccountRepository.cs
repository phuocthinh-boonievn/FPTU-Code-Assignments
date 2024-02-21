using WPF_BO.Models;
using WPF_DAO;

namespace WPF_Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(string id) => AccountDAO.Instance.GetAccount(id);

        public List<Account> GetAccounts() => AccountDAO.Instance.GetAccounts();
    }
}