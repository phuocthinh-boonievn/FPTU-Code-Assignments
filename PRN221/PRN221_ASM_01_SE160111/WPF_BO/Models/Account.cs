using System;
using System.Collections.Generic;

namespace WPF_BO.Models
{
    public partial class Account
    {
        public Account()
        {
            Products = new HashSet<Product>();
            Stores = new HashSet<Store>();
        }

        public short UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long Role { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
