using WPF_Repository;
using WPF_BO;

namespace WPF_Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository = null;

        public AccountService()
        {
            accountRepository = new AccountRepository();
        }
        public Account GetAccount(string id)
        {
            return accountRepository.GetAccount(id);
        }

        public List<Account> GetAccounts()
        {
            return accountRepository.GetAccounts();
        }
    }
}