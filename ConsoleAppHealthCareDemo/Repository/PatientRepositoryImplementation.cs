using ConsoleAppHealthCareDemo.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SQLServerConnectionLibrary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHealthCareDemo.Repository
{
    public class PatientRepositoryImplementation : IPatientRepository
    {
        //Get Database Connection
        //1 Retrieve ConnectionString from App.Config
        string winConnString = ConfigurationManager.ConnectionStrings["CsWinOne"].ConnectionString;

        public Task  AddPatientAsync(Patient patient)
        {
            //
            using (SqlConnection conn = SQlServerConnectionManager.OpenConnection(winConnString))
            {

                //perform Insert query
                //@variables are dummy variables take input from user to get filled

            }

            //Insert 
        }
    }
}
