using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApp
{
    public class MedicalRecord<T>
    {
        public List<T> Records = new List<T>();
        public MedicalRecord() { }
        public void AddRecord(T record) => Records.Add(record);

        public IEnumerable<T> GetAllRecords() => Records.AsEnumerable();

        public void RemoveRecord(T record) => Records.Remove(record);

        public int GetRecordCount() => Records.Count;

    }
}
