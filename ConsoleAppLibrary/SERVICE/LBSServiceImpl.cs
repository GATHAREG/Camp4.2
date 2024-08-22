using ConsoleAppLibraryWithDb.MODEL;
using ConsoleAppLibraryWithDb.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryWithDb.SERVICE
{
    public class LBSServiceImpl:ILBSService
    {
        //field
        private readonly ILBSRepository _libraryRepository;
        //constructor injection
        public LBSServiceImpl(ILBSRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public async Task AddBookAsync(Book book)
        {
            await _libraryRepository.AddBookAsync(book);
        }

        public async Task DeleteBookAsync(string bookCode)
        {
            await _libraryRepository.DeleteBookAsync(bookCode);

        }
        public async Task<List<Book>> GetBooksAsync()
        {
            List<Book> books = new List<Book>();
            books = await _libraryRepository.GetBooksAsync();
            return books;
        }

        public async Task<Book> GetBookByCodeAsync(string bookCode)
        {
            var book = await _libraryRepository.GetBookByCodeAsync(bookCode);
            return book;
        }

        public async Task UpdateBookAsync(string bookCode, Book updatedBook)
        {
            await _libraryRepository.UpdateBookAsync(bookCode, updatedBook);
        }
    }
}
