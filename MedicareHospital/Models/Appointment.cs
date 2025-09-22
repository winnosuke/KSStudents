using System;
using System.Collections.Generic;

namespace MedicareHospital.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = "Scheduled"; // Scheduled, Completed, Cancelled

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
