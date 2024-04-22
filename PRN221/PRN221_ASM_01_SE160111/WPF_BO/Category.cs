using System;
using System.Collections.Generic;

namespace WPF_BO
{
    public partial class Category
    {
        public Category()
        {
            Pcs = new HashSet<Pc>();
        }

        public short CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}
