using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BO;

namespace WPF_Service
{
    public interface IAccountService
    {
        public Account GetAccount(string id);
        public List<Account> GetAccounts();
    }
}
