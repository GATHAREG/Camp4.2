using ConsoleAppLibraryWithDb.MODEL;
using ConsoleAppLibraryWithDb.REPOSITORY;
using ConsoleAppLibraryWithDb.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryWithDb
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ILBSService bookService = new LBSServiceImpl(new LMSRepositoryImpl());
            

            

            //MENU DRIVEN
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Library Management system");
                Console.WriteLine("1.ADD BOOK");
                Console.WriteLine("2.UPDATE BOOK");
                Console.WriteLine("3.GET BOOK BY CODE");
                Console.WriteLine("4.GET ALL BOOKS");
                Console.WriteLine("5.DELETE BOOK");
                Console.WriteLine("8.EXIT");
                Console.Write("ENTER YOUR CHOICE : ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await AddBook(bookService);
                        break;
                    case "2":
                        await EditBook(bookService);
                        break;
                    case "3":
                        await searchBook(bookService);
                        break;
                    case "4":
                        await listBook(bookService);
                        break;
                    case "5":
                        await deleteBook(bookService);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:Console.WriteLine("Invalid choice.");
                        break;


                }


            }
            Console.ReadKey();
        }

        private static async Task listBook(ILBSService bookService)
        {
            List<Book> books = new List<Book>();
                books= await bookService.GetBooksAsync();
            Console.WriteLine($"\n |  Title {-15}|Author{-15}|Price{0-10}|Genre{0-10}");
            foreach (var book in books)
            {
                Console.WriteLine($"\n | {book.Title} {-15}|{book.Author}{-15}|{book.Price}{-10}|{book.Genre}{-10}");
            }

        }

        private static async Task deleteBook(ILBSService bookService)
        {
            Console.Write("Enter BookCode to be deleted :");
            string bookCode = Console.ReadLine();
            await bookService.DeleteBookAsync(bookCode);

        }

        private static async Task EditBook(ILBSService bookService)
        {
            string Author = string.Empty;
            int Price = 0;
            string genre = string.Empty;
            Console.Write("Enter Book Code to be updated : ");
            string bookCode = Console.ReadLine();
            var book = await bookService.GetBookByCodeAsync(bookCode);
            Console.WriteLine($"\nBook Code    : {book.BookCode}");
            Console.WriteLine($"Title          :{book.Title}");
            Console.WriteLine($"Author          :{book.Author}");
            Console.WriteLine($"Price           :{book.Price}");
            Console.WriteLine($"Genre           :{book.Genre}");
            Console.WriteLine("\nYou can update Author,Price and Genre of Employee.");
            Console.Write("Enter new Author,Leave to remain current value: ");
            Author = Console.ReadLine();
            Console.Write("Enter Price,Leave to remain current value: ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Genre,leave to remain current value:");
            genre = Console.ReadLine();
            if (!string.IsNullOrEmpty(Author))
            {
                book.Author = Author;            }
            if (Price!= 0)
            {
                book.Price = Price;
            }
            if (!string.IsNullOrEmpty(genre))
            {
                book.Genre = genre;
            }
            await bookService.UpdateBookAsync(bookCode,book);

        }

        private static async Task searchBook(ILBSService bookService)
        {
            Console.Write("Enter Book Code to be search : ");
            string bookCode = Console.ReadLine();

            var book = await bookService.GetBookByCodeAsync(bookCode);
            Console.WriteLine($"\n Book Code    :{book.BookCode}");
            Console.WriteLine($" Title          :{book.Title}");
            Console.WriteLine($" Author         :{book.Author}");
            Console.WriteLine($" Price          :{book.Price}");
            Console.WriteLine($" Genre          :{book.Genre}");

        }
        private static async Task AddBook(ILBSService bookService)
        {
            var book = new Book();
            //EMPCODE
            Console.Write("Enter Book Code : ");
            book.BookCode = Console.ReadLine();

            Console.Write("Enter Title : ");
            book.Title = Console.ReadLine();

            Console.Write("Enter Author : ");
            book.Author = Console.ReadLine();

            Console.Write("Enter Genre :");
            book.Genre = Console.ReadLine();

            Console.Write("Enter Price : ");
            book.Price = Convert.ToInt32(Console.ReadLine());

            await bookService.AddBookAsync(book);
            // Console.WriteLine("Employee  added successfully");
        }
    }
    }


