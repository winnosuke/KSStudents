using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApp
{
    public class Patient
    {
        public Patient()
        {
        }

        public int PatientID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string BloodType { get; set; }
        public decimal TreatmentCost { get; set; }
        
        public string GetAgeCategory(Patient patients)
        {

            
                if (patients.Age < 18)
                {
                    return "Child";
                }
                else if (patients.Age > 65)
                {
                    return "Senior";
                }
                else
                {
                    return "Adult";
                }
            
            return null;
        }

        public override string? ToString()
        {
            return $"{PatientID} - {FullName} ({Age} years, {BloodType}) - Cost : ${TreatmentCost}";
        }
    }
}
