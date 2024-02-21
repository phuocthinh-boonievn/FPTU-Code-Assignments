using HospitalManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement_Repository
{
    public interface IAccountRepository
    {
        public StaffAccount GetAccount(string id);
        public List<StaffAccount> GetAccounts();
        public void AddAccount(StaffAccount account);
        public void UpdateAccount(StaffAccount account);
        public void DeleteAccount(string id);
    }
}
