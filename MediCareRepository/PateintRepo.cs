using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicareHospital.Models;

namespace MediCareRepository
{
    public class PateintRepo
    {
        private readonly DbMediCareContext _context;

        public PateintRepo(DbMediCareContext context)
        {
            _context = context;
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient? GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public void Add(Patient grade)
        {
            _context.Patients.Add(grade);
            _context.SaveChanges();
        }

        public void Update(Patient grade)
        {
            _context.Patients.Update(grade);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var grade = _context.Patients.Find(id);
            if (grade != null)
            {
                _context.Patients.Remove(grade);
                _context.SaveChanges();
            }
        }
    }
}