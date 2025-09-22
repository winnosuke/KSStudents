using System;
using System.Collections.Generic;

namespace MedicareHospital.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorCode { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
