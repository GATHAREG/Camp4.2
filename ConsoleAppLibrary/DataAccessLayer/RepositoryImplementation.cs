using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibrary.DataAccessLayer
{
    public class RepositoryImplementation : IRepository
    { //storing in books
        public const string filePath = "Books.json";
        public Dictionary<string, Books> GetAll()
        {
            if(File.Exists(filePath))
            {
                string jsondata = File.ReadAllText(filePath);
                 return JsonConvert.DeserializeObject <Dictionary<string,Books>>(jsondata);   
            }
            else
            {
                return new Dictionary<string, Books> ();
            }
        }

        public void SaveBooks(Dictionary<string, Books> book)
        {
            // to store into the file
            string jsondata = JsonConvert.SerializeObject(book, Formatting.Indented);
            File.WriteAllText(filePath, jsondata);
        }
    }
}
