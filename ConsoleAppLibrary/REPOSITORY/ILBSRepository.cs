using ConsoleAppLibraryWithDb.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryWithDb.REPOSITORY
{
    public interface ILBSRepository
    {
        //INSERT
        Task AddBookAsync(Book Book);

        //UPDATE
        Task UpdateBookAsync(string bookCode, Book updatedbook);

        // SEARCH BY EMPCODE
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookByCodeAsync(string bookCode);

        Task DeleteBookAsync(string bookCode);

    }
}
