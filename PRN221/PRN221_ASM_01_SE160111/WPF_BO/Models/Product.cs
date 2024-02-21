using System;
using System.Collections.Generic;

namespace WPF_BO.Models
{
    public partial class Product
    {
        public short ProductId { get; set; }
        public string Title { get; set; } = null!;
        public long Description { get; set; }
        public string ImageLink { get; set; } = null!;
        public long? Review { get; set; }
        public bool Status { get; set; }
        public short UserId { get; set; }
        public short CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Account User { get; set; } = null!;
    }
}
