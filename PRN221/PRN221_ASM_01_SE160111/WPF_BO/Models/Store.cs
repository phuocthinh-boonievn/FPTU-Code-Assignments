using System;
using System.Collections.Generic;

namespace WPF_BO.Models
{
    public partial class Store
    {
        public short StoreId { get; set; }
        public string Address { get; set; } = null!;
        public string StoreDescription { get; set; } = null!;
        public bool Status { get; set; }
        public long Inventory { get; set; }
        public short UserId { get; set; }

        public virtual Account User { get; set; } = null!;
    }
}
