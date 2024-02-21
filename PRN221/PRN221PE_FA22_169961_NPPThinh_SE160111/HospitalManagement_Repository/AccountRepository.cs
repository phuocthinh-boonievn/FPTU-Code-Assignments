using HospitalManagement_BusinessObjects;
using HospitalManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement_Repository
{
    public class AccountRepository : IAccountRepository
    {
        public StaffAccount GetAccount(string id) => AccountDAO.Instance.GetAccount(id);

        public List<StaffAccount> GetAccounts() => AccountDAO.Instance.GetAccounts();
        public void AddAccount(StaffAccount account) => AccountDAO.Instance.AddAccount(account);
        public void UpdateAccount(StaffAccount account) => AccountDAO.Instance.UpdateAccount(account);

        public void DeleteAccount(string id) => AccountDAO.Instance.DeleteAccount(id);
    }
}
