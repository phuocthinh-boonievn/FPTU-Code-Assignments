using System;
using System.Collections.Generic;

namespace HospitalManagement_BusinessObjects
{
    public class StaffAccount
    {
        public string HraccountId { get; set; } = null!;
        public string Hrfullname { get; set; } = null!;
        public string Hremail { get; set; } = null!;
        public string? Hrpassword { get; set; }
        public int? StaffRole { get; set; }
    }
}
