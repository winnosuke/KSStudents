using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicareHospital.Models;

namespace MediCareRepository
{
    public class DoctorRepo
    {
        private readonly DbMediCareContext _context;

        public DoctorRepo(DbMediCareContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor? GetById(int id)
        {
            return _context.Doctors.Find(id);
        }

        public void Add(Doctor grade)
        {
            _context.Doctors.Add(grade);
            _context.SaveChanges();
        }

        public void Update(Doctor grade)
        {
            _context.Doctors.Update(grade);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var grade = _context.Doctors.Find(id);
            if (grade != null)
            {
                _context.Doctors.Remove(grade);
                _context.SaveChanges();
            }
        }
    }
}