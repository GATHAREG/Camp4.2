using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibrary.DataAccessLayer
{
    public interface IRepository
    {
        Dictionary<string, Books> GetAll();

        void SaveBooks(Dictionary<string, Books> book);
    }
}
