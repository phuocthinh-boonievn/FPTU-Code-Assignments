using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BO;

namespace WPF_Repository
{
    public interface IAccountRepository
    {
        public Account GetAccount(string id);
        public List<Account> GetAccounts();
    }
}
