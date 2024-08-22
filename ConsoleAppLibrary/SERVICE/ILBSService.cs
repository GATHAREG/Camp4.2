using ConsoleAppLibraryWithDb.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryWithDb.SERVICE
{
    public interface ILBSService
    {
        //INSERT
        Task AddBookAsync(Book book);
        //UPDATE
        Task UpdateBookAsync(string bookCode, Book updatedbook);
        //SEARCH BY EMPCODE
        Task<Book> GetBookByCodeAsync(string bookCode);

        Task DeleteBookAsync(string bookCode);
        Task<List<Book>> GetBooksAsync();

    }
}
