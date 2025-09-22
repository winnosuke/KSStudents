using System;
using System.Linq;
namespace PatientRecordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicalRecord<string> medicalString = new MedicalRecord<string>();
            Console.WriteLine("Patient Record Management System");
            Console.WriteLine("Dianogsis record");
            medicalString.AddRecord("A ");
            medicalString.AddRecord("B ");
            medicalString.AddRecord("O ");
            Console.WriteLine("Total Diagnoses : ");
            Console.WriteLine(medicalString.GetRecordCount());

            Console.WriteLine("All Diagnoses : ");
            foreach (var medical in medicalString.GetAllRecords())
            {
                Console.WriteLine(medical);
            }        

            MedicalRecord<Patient> medicalRecord = new MedicalRecord<Patient>();

            medicalRecord.AddRecord(new Patient { PatientID = 1, FullName = "Nguyen Van A", Age = 18, BloodType = "A", TreatmentCost = 20 });
            medicalRecord.AddRecord(new Patient { PatientID = 2, FullName = "Nguyen Van B", Age = 66, BloodType = "B", TreatmentCost = 600 });
            medicalRecord.AddRecord(new Patient { PatientID = 3, FullName = "Nguyen Van C", Age = 23, BloodType = "AB", TreatmentCost = 400 });
            medicalRecord.AddRecord(new Patient { PatientID = 4, FullName = "Nguyen Van D", Age = 10, BloodType = "O", TreatmentCost = 550 });

            Console.WriteLine("All Patient");
            Console.WriteLine($"Total Patient : {medicalRecord.GetRecordCount()}");
            foreach (var record in medicalRecord.GetAllRecords()) { Console.WriteLine(record); }
            Console.WriteLine("Treatment cost greater than $500");
            var treamentCostGreatThan500 = medicalRecord.GetAllRecords().Where(s => s.TreatmentCost > 500).ToList();
            foreach (var cost in treamentCostGreatThan500)
            {
                Console.WriteLine(cost);
            }

            var category = medicalRecord.GetAllRecords().GroupBy(s => s.GetAgeCategory(s));

            foreach (var group in category)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} patient");
                foreach (var patient in group)
                {
                    Console.WriteLine(patient);
                }
            }

        }
    }



    public class MedicalRecord<T>
    {
        public List<T> Records = new List<T>();
        public MedicalRecord() { }
        public void AddRecord(T record) => Records.Add(record);

        public IEnumerable<T> GetAllRecords() => Records.AsEnumerable();

        public void RemoveRecord(T record) => Records.Remove(record);

        public int GetRecordCount() => Records.Count;

    }



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

