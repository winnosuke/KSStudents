namespace PatientRecordApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MedicalRecord<string> medicalString = new MedicalRecord<string>();
            Console.WriteLine("============Patient Record Management System=================");
            Console.WriteLine("===========Dianogsis record===============");
            medicalString.AddRecord("dau da day ");
            medicalString.AddRecord("dau bung ");
            medicalString.AddRecord("dau rang ");
            Console.WriteLine("Total Diagnoses : ");
            Console.WriteLine(medicalString.GetRecordCount());

            Console.WriteLine("All Diagnoses : ");
            foreach (var medical in medicalString.GetAllRecords()) { 
                Console.WriteLine(medical);
            }
            Console.WriteLine("=====================================================================");

            MedicalRecord<Patient> medicalRecord = new MedicalRecord<Patient>();

            medicalRecord.AddRecord(new Patient { PatientID =  1, FullName =  "Nguyen Van A", Age = 18, BloodType =  "daubung", TreatmentCost =  20 });
            medicalRecord.AddRecord(new Patient { PatientID = 2, FullName = "Nguyen Van B", Age = 66, BloodType = "daubung", TreatmentCost = 600 });
            medicalRecord.AddRecord(new Patient { PatientID = 3, FullName = "Nguyen Van C", Age = 23, BloodType = "dau rang", TreatmentCost = 400 });
            medicalRecord.AddRecord(new Patient { PatientID = 4, FullName = "Nguyen Van D", Age = 10, BloodType = "dau da day", TreatmentCost = 550 });

            Console.WriteLine("All Patient");
            Console.WriteLine($"Total Patient : {medicalRecord.GetRecordCount()}");
            foreach(var record in medicalRecord.GetAllRecords()) { Console.WriteLine(record); }
            Console.WriteLine("Treatment cost greater than $500");
            var treamentCostGreatThan500 = medicalRecord.GetAllRecords().Where(s => s.TreatmentCost > 500).ToList();
            foreach(var cost in treamentCostGreatThan500)
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
}
