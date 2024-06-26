﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_BO;

namespace WPF_DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private readonly wpfManagementContext dBContext = null;
        public AccountDAO()
        {
            if (dBContext == null)
            {
                dBContext = new wpfManagementContext();
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
        public List<Account> GetAccounts()
        {
            return dBContext.Accounts.ToList();
        }
        public Account GetAccount(string id)
        {
            return dBContext.Accounts.FirstOrDefault(m => m.Username.Equals(id));
        }
    }
}
