using System;
using System.Collections.Generic;

namespace WPF_BO
{
    public partial class Store
    {
        public Store()
        {
            Pcs = new HashSet<Pc>();
        }

        public short StoreId { get; set; }
        public string StoreLocation { get; set; } = null!;

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
