using ConsoleAppLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibrary.Service
{
    public class Library : ILibrary
    {
        private readonly IRepository _bookrepository;
        
        //constructor
        public Library(IRepository bookrepository)
        {
            _bookrepository = bookrepository; 
        }
        
        
        // using dictionary to store isbn as key and BOOks objects as values
        public Dictionary<string, Books> book = new Dictionary<string, Books>();
       
        
         
                                                                                   


        
        public string isbn = "b1";


        // implementing all unimplemented methods of ILibrary
        public void AddBooks()
        {
            try
            {
                // receiving user input of all values

              
                while (true)
                { /*while (true)
                    {
                        Console.WriteLine("Enter the Isbn Number");
                        isbn = Console.ReadLine();
                        //checking validation
                        if (string.IsNullOrWhiteSpace(isbn))    
                        {

                            Console.WriteLine("Invalid isbn!please try again ");


                        }
                        else
                        {
                            break;
                        }
                    } */
                    

                    string title;
                    while (true)
                    {
                        Console.WriteLine("Enter the title of book");
                        title = Console.ReadLine();
                        //checking validation
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Invalid isbn!please try again ");
                            
                        }
                        else
                        {
                            break;
                        }
                    }
                    string author;
                    while (true)
                    {

                        Console.WriteLine("Enter the author of book:");
                        author = Console.ReadLine();
                        //checking validation
                        if (string.IsNullOrWhiteSpace(author))
                        {
                            Console.WriteLine("Invalid isbn!please try again ");

                        }
                        else
                        {
                            break;
                        }
                    }
                    string description;
                    while (true)
                    {
                        Console.WriteLine("Enter the description about boooks");
                        description = Console.ReadLine();
                        //checking validation
                        if (string.IsNullOrWhiteSpace(description))
                        {
                            Console.WriteLine("Invalid isbn!please try again ");

                        }
                        else
                        {
                            break;
                        }
                    }
                    decimal price;
                    while (true)
                    {
                        Console.WriteLine("Enter the price of books");
                        price = 0;
                        //checking the entered price is decimal
                        if (!decimal.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Invalid value for price ! try again");

                        }
                        else
                        {
                            break;
                        }
                    }
                    DateTime published_date;
                    while (true)
                    {
                        Console.WriteLine("Enter the date of published (YYYY-MM-DD)");
                        //checkking date before today 

                        if ((!DateTime.TryParse(Console.ReadLine(), out published_date)) || published_date >= DateTime.Now)
                        {
                            Console.WriteLine("INVALID DATE.PLEASE ENTER IN CORRECT FORMAT");

                        }
                        else
                        {
                            break;
                        }
                    }
                    bool status;


                    Console.WriteLine("Enter the status of availability:");

                    while (true)
                    {
                        Console.WriteLine("Is the book is available? (Yes/No):");
                        char statusinput = Console.ReadLine().Trim().ToLower()[0];
                        if (statusinput == 'y')
                        {
                            status = true;
                            break;
                        }
                        else if (statusinput == 'n')
                        {
                            status = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for InService.PLease Enter 'yes' or 'no'.");
                        }
                    }
                    string isbn = "b" + book.Count;
                    Console.WriteLine($"The generated isbn is {isbn}");

                    book.Add(isbn, new Books
                    {
                        ISBN = isbn,
                        Title = title,
                        Author = author,
                        Description = description,
                        Price = price,
                        PublishedDate = published_date,
                        IsAvailable = status



                    });
                    

                    Console.WriteLine("Book added successfully");
                    Console.WriteLine($"The count of books are {book.Count}");
                    _bookrepository.SaveBooks(book);

                    break;




                }  
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // edit books function taking isbn as parameter
        public void EditBooks(string isbn)
        {
            try
            {
                if (book.TryGetValue(isbn, out var books))
                {
                    Console.WriteLine("Select the option you want to edit ");
                    Console.WriteLine("1.The price of the book");
                    Console.WriteLine("2.The description of book");
                    Console.WriteLine("3.Availability status");
                    Console.WriteLine("Enter the choice:");
                    int choice = 0;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid choice.");

                    }
                    else if (choice == 1)
                    {
                        decimal price;
                        while (true)
                        {


                            Console.WriteLine($"The current price of book is{books.Price}");
                            Console.WriteLine("Enter the new price");

                            if (!decimal.TryParse(Console.ReadLine(), out price))
                            {
                                Console.WriteLine("Invalid value for price ! try again");
                                
                                
                            }
                            books.Price = price;
                            Console.WriteLine("Book updated successfully");
                            SearchById(isbn);
                            break;
                        }
                    }
                    else if (choice == 2)
                    {
                        string description;
                        while (true)
                        {

                            Console.WriteLine($"The current description of boook is {books.Description}");
                            Console.WriteLine("Enter the new description");
                            description = Console.ReadLine();
                            if (string.IsNullOrEmpty(description))

                            {
                                Console.WriteLine("Enter proper description");
                            }
                            books.Description = description;
                            Console.WriteLine("Book updated successfully");
                           
                            SearchById(isbn);
                            break;
                        }
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine($"The current status of book is{books.IsAvailable}");
                        bool status;
                        while (true)
                        {
                            Console.WriteLine("Update the employee status in service into (Yes/No):");
                            char inStatus = Console.ReadLine().Trim().ToLower()[0];
                            if (inStatus == 'y')
                            {
                                status = true;
                                break;
                            }
                            else if (inStatus == 'n')
                            {
                                status = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for InService.PLease Enter 'yes' or 'no'.");
                            }
                        }
                        books.IsAvailable = status;
                        Console.WriteLine("Book updated successfully");
                        SearchById(isbn);
                       

                    }
                    _bookrepository.SaveBooks(book);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // listing all books
        public void ListAllBooks()
        {
            if (book.Count < 0)
            {
                book = new Dictionary<string, Books>();
                Console.WriteLine("No records found");
            }
            else
            {
                book = _bookrepository.GetAll();
                foreach (var bookies in book.Values)
                {
                    Console.WriteLine("The book details of library are:");


                    Console.WriteLine($"{"THE ISBN OF BOOK IS",-30}| {"THE TITLE OF BOOK IS ",-28}|{" THE AUTHOR OF BOOK IS",-19} | {"THE DESCRIPTION OF BOOKS",-14 }| {"THE PRICE OF BOOK IS",-8}| {"THE DATE OF PUBLISHING IS",-4} | {"THE AVAILABILITY STATUS"}");
                    Console.WriteLine($"{bookies.ISBN,-30} | {bookies.Title,-28} | {bookies.Author,-19} |  {bookies.Description,-14} | {bookies.Price,-8}| {bookies.PublishedDate,-4} | {bookies.IsAvailable}");
                }
               
            }
        }

        //deleting books of specified isbn by turning the availability status to false
        public void RemoveBooks(string isbn)
        {
            try
            {
                if (book.TryGetValue(isbn, out var books))
                {
                    Console.WriteLine("Are you Sure Want to delete?\n 1.Yes\n 2.No");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        books.IsAvailable = false;
                        Console.WriteLine($"Employee deleted successfully");
                        SearchById(isbn);
                        

                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Deletion Cancelled");
                        return;

                    }


                }
                else
                {
                    Console.WriteLine("invalid");
                }

            }
            catch (Exception ex) { }
        }
        //searching function by title,author,id

        public void SearchByAuthor(string author)
        {
            try
            {
               foreach(var bookies in book.Values)
                {
                    if (bookies.Author.Equals(author))
                    {

                        Console.WriteLine("The book details of library are:");
                        Console.WriteLine($"THE ISBN OF BOOK IS {bookies.ISBN}\n THE TITLE OF BOOK IS {bookies.Title}\n  THE AUTHOR OF BOOK IS {author}\n THE DESCRIPTION OF BOOKS {bookies.Description}\nTHE PRICE OF BOOK IS{bookies.Price}\nTHE DATE OF PUBLISHING IS{bookies.PublishedDate}\n THE AVAILABILITY STATUS{bookies.IsAvailable}");


                    }
                    else
                    {
                        Console.WriteLine("Book not found!");
                    }
                } 
             /*  if(book.TryGetValue(author, out var books))
                {

                } */
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

         public void SearchById(string isbn)
         {
            try
            {
                if (book.TryGetValue(isbn, out var books))
                {
                    Console.WriteLine("The book details of library are:");
                    Console.WriteLine($"THE ISBN OF BOOK IS {books.ISBN}\n THE TITLE OF BOOK IS {books.Title}\n  THE AUTHOR OF BOOK IS {books.Author}\n THE DESCRIPTION OF BOOKS {books.Description}\nTHE PRICE OF BOOK IS{books.Price}\nTHE DATE OF PUBLISHING IS{books.PublishedDate}\n THE AVAILABILITY STATUS{books.IsAvailable}");
                }
                else
                {
                    Console.WriteLine("Book not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SearchByTitle(string title)
        {
            try
            {
                foreach (var bookies in book.Values)
                {
                    if (bookies.Title.Equals(title))
                    {

                        Console.WriteLine("The book details of library are:");
                        Console.WriteLine($"THE ISBN OF BOOK IS {bookies.ISBN}\n THE TITLE OF BOOK IS {title}\n  THE AUTHOR OF BOOK IS {bookies.Author}\n THE DESCRIPTION OF BOOKS {bookies.Description}\nTHE PRICE OF BOOK IS{bookies.Price}\n,THE DATE OF PUBLISHING IS{bookies.PublishedDate}\n THE AVAILABILITY STATUS{bookies.IsAvailable}");


                    }
                    else
                    {
                        Console.WriteLine("Book not found!");
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    }
