using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHealthCareDemo.Model
{
    //patient details;
    //patient ID, name, age, diagnosis, and treatment plan.
    public class Patient
    {
        //auto generate id
        private int Id;
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string Diagnosis {  get; set; }
        public string TreatmentPlan { get; set; }

        //default constructor
        public Patient()
        {
            
        }
        //parameterised constructor
        public Patient(string patientId,string patientName,int patientAge,string diagnosis, string treatmentPlan)
        {
            this.PatientId = patientId;
            this.PatientName = patientName;
            this.PatientAge = patientAge;
            this.Diagnosis = diagnosis;
            this.TreatmentPlan = treatmentPlan;
        }


    }
}
