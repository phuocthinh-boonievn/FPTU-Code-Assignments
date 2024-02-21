using System;
using System.Collections.Generic;

namespace HospitalManagement_BusinessObjects
{
    public partial class DoctorInformation
    {
        public string DoctorId { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Email { get; set; } = null!;
        public string? DoctorAddress { get; set; }
        public int? GraduationYear { get; set; }
        public string? DoctorLicenseNumber { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
