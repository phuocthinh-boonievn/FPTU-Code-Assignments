using System;
using System.Collections.Generic;

namespace WPF_BO
{
    public partial class Account
    {
        public Account()
        {
            Pcs = new HashSet<Pc>();
        }

        public short UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Status { get; set; }
        public long Role { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
