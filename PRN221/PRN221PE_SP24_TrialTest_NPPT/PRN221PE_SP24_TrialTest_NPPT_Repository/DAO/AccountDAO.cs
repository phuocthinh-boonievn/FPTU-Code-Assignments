using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;

namespace PRN221PE_SP24_TrialTest_NPPT_Repository.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private readonly Eyeglasses2024DbContext dBContext = null;
        public AccountDAO()
        {
            if (dBContext == null)
            {
                dBContext = new Eyeglasses2024DbContext();
            }
        }
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public StoreAccount GetAccount(string email)
        {
            return dBContext.StoreAccounts.FirstOrDefault(m => m.EmailAddress.Equals(email));
        }

        public List<StoreAccount> GetAccounts()
        {
            return dBContext.StoreAccounts.ToList();
        }

    }

}
