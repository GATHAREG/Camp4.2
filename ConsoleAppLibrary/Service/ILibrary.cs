using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibrary.Service
{
    public  interface ILibrary
    {
        // abstracts methods are defined
       public void AddBooks();
       public void ListAllBooks();
       public void EditBooks(string _isbn);
       public void RemoveBooks(string _isbn);

        public void SearchByAuthor(string _author);
        public void SearchByTitle(string _title);

        public void SearchById(string _isbn);
    }
}
