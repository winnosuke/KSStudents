using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicareHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace MediCareRepository
{
    public class AppointmentRepo
    {
   private readonly DbMediCareContext _context;

    public AppointmentRepo(DbMediCareContext context)
    {
        _context = context;
    }

    public List<Appointment> GetAll()
    {
        return _context.Appointments.ToList();
    }

    public List<Appointment> GetByDoctor(int doctorId)
    {
        // Include Patient for display
        return _context.Appointments
            .Include(a => a.Patient)
            .Where(a => a.DoctorId == doctorId)
            .OrderBy(a => a.AppointmentDate)
            .ToList();
    }

    public Appointment? GetById(int id)
    {
        return _context.Appointments.Find(id);
    }

    public void Add(Appointment grade)
    {
        _context.Appointments.Add(grade);
        _context.SaveChanges();
    }

    public void Update(Appointment grade)
    {
        _context.Appointments.Update(grade);
        _context.SaveChanges();
    }

    public void UpdateStatus(int appointmentId, string status)
    {
        var appt = _context.Appointments.Find(appointmentId);
        if (appt != null)
        {
            appt.Status = status;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var grade = _context.Appointments.Find(id);
        if (grade != null)
        {
            _context.Appointments.Remove(grade);
            _context.SaveChanges();
        }
    }
}
}