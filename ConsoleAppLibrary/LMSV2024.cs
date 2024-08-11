using ConsoleAppLibrary.DataAccessLayer;
using ConsoleAppLibrary.Service;
using System.Runtime.CompilerServices;

namespace ConsoleAppLibrary
{
    public class LMSV2024
    { 
        // using the interface reference to perform dependency injection of object creation
        private readonly ILibrary _library;
        public LMSV2024(ILibrary library) { 
        
        
            _library = library;
        
        }

       

        static void Main(string[] args) {
            var lmsApp = new LMSV2024(new Library(new RepositoryImplementation()));

            


            while (true)
            {
                // menu driven
                Console.WriteLine("Welcome to Library Management system 2024");
                Console.WriteLine("The main features are:");
                Console.WriteLine("1.Add Books");
                Console.WriteLine("2.Edit Books");
                Console.WriteLine("3.Search Book");
                Console.WriteLine("4.ListAllBooks");
                Console.WriteLine("5.Remove Book");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter your choice");
                int choice;
                if(!int.TryParse(Console.ReadLine(), out choice)|| choice<1 || choice> 6)
                {
                    Console.WriteLine("Invalid choice ! please try again");
                    
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            lmsApp._library.AddBooks();
                            break;
                        case 2:
                            Console.WriteLine("Enter the isbn to update");
                            string isbn = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(isbn))
                            {
                                Console.WriteLine("Invalid input");
                            }
                            lmsApp._library.EditBooks( isbn);
                            break;
                        case 3:
                            Console.WriteLine("1.Search Book BY ID");
                            Console.WriteLine("2.Search Book By Title");
                            Console.WriteLine("3.Search Book By Author");
                            Console.WriteLine("Enter Your Choice");
                            int subchoice;
                            if (!int.TryParse(Console.ReadLine(), out subchoice) || subchoice < 1 || choice > 3)
                            {
                                Console.WriteLine("Invalid choice ! please try again");
                                break;
                            }
                            else if(subchoice == 1)
                            {
                                Console.WriteLine("Enter the id");
                                string isbnn = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(isbnn))
                                {
                                    Console.WriteLine("Invalid input");
                                }
                                lmsApp._library.SearchById(isbnn);
                                break;
                            }
                            else if(subchoice == 2)
                            {
                                Console.WriteLine("Enter the Title");
                                string title = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(title))
                                {
                                    Console.WriteLine("Invalid input");
                                }
                                lmsApp._library.SearchByTitle(title);
                            }
                            else if(subchoice == 3)
                            {
                                Console.WriteLine("Enter the Author name");
                                string author = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(author))
                                {
                                    Console.WriteLine("Invalid input");
                                }
                                lmsApp._library.SearchByAuthor(author);

                            }
                            break;
                        case 4:
                            
                            lmsApp._library.ListAllBooks();
                            break;
                        case 5:
                            Console.WriteLine("Enter the isbn id to delete");
                            string _isbn = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(_isbn))
                            {
                                Console.WriteLine("Invalid input");
                            }
                            else { lmsApp._library.RemoveBooks(_isbn); }
                            break;
                        case 6:
                            return;
                            Environment.Exit(0);
                                
                            break;

                    }
                }
            }

           

    }   
        
    }
}
