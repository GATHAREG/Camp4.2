using ConsoleAppHealthCareDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHealthCareDemo.Repository
{
    public interface IPatientRepository
    {
        //Data Access layer
        //insert
        Task  AddPatientAsync(Patient patient);
    }
}
