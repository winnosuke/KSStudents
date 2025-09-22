using System;
using System.Collections.Generic;

namespace MedicareHospital.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientCode { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int? Age { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
