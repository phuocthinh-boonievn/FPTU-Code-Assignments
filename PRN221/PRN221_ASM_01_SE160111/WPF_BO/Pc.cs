using System;
using System.Collections.Generic;

namespace WPF_BO
{
    public partial class Pc
    {
        public short ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public long Price { get; set; }
        public string? ImageLink { get; set; }
        public long? Review { get; set; }
        public bool Status { get; set; }
        public short? UserId { get; set; }
        public short CategoryId { get; set; }
        public short? StoreId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Store? Store { get; set; }
        public virtual Account? User { get; set; }
    }
}
