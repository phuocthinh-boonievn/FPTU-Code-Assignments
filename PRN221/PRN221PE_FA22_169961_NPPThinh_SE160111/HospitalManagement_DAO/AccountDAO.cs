using HospitalManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement_DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private readonly HospitalManagementDBContext dBContext = null;
        public AccountDAO()
        {
            if(dBContext == null)
            {
                dBContext = new HospitalManagementDBContext();
            }
        }
        public static AccountDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public StaffAccount GetAccount(string id)
        {
            return dBContext.StaffAccounts.FirstOrDefault(m => m.HraccountId.Equals(id));
        }

        public List<StaffAccount> GetAccounts()
        {
            return dBContext.StaffAccounts.ToList();
        }

        public void AddAccount(StaffAccount account)
        {
            StaffAccount staff = GetAccount(account.HraccountId);
            if(staff == null) 
            {
                dBContext.StaffAccounts.Add(account);
                dBContext.SaveChanges();
            }
        }

        public async void UpdateAccount(StaffAccount account)
        {
            StaffAccount staff = GetAccount(account.HraccountId);
            if (staff != null)
            {
                dBContext.Attach(account).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
            }
        }
        public void DeleteAccount(string id)
        {
            StaffAccount staff = GetAccount(id);
            if (staff != null)
            {
                dBContext.Remove(staff);
                dBContext.SaveChanges();
            }
        }

    }
}
