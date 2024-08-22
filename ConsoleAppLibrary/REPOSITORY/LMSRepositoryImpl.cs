using ConsoleAppLibraryWithDb.MODEL;
using SQLSERVERCONNECTIONLIBRARY;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLibraryWithDb.REPOSITORY
{
   public class LMSRepositoryImpl:ILBSRepository
    {
        string WindowconnString = ConfigurationManager.ConnectionStrings["CSHARPWINDOW"].ConnectionString;


        //INSERT
        public async Task AddBookAsync(Book book)
        {
            using (SqlConnection con = SqlServerConnectionManager.OpenConnection(WindowconnString))
            {

                //perform insert query
                string query = "INSERT INTO Library(BookCode,Title,Author,Genre,Price)" +
                    "VALUES(@BookCode,@Title,@Author,@Genre,@Price)";
                //SQLCOMMAND
                //SELECT-EXECUTEQUERY()
                //INSERT/UPDATE/DELETE-EXECUTENONQUERY()
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@BookCode", book.BookCode);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@Price",book.Price);
                    /* await con.OpenAsync();*/
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine("Book Added Successfully..");

                }
            }
        }
        //DELETE
        public async Task DeleteBookAsync(string bookCode)
        {
            // Open a database connection
            using (SqlConnection con = SqlServerConnectionManager.OpenConnection(WindowconnString))
            {
                // SQL query to delete an Library
                string query = "DELETE FROM Library WHERE BookCode=@BookCode";

                // Prepare the command with the query and connection
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add parameter 
                    command.Parameters.AddWithValue("@BookCode", bookCode);

                    // Execute the query asynchronously
                    await command.ExecuteNonQueryAsync();

                    // Confirm deletion
                    Console.WriteLine("Book Deleted Successfully.");
                }
            }
        }
        //List
        public async Task<List<Book>> GetBooksAsync()
        {
            //Declare a list to add record fetched from database
            List<Book> books = new List<Book>();
            //Open a database connection
            using (SqlConnection con = SqlServerConnectionManager.OpenConnection(WindowconnString))
            {
                //Sql querry for select all details from table
                string query = "SELECT * FROM Library";

                //Prepare the command with query  and connection
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Fetch each records from reader class
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {//Assign values to object and add each object to list
                            Book book = new Book
                            {
                                BookCode = reader["BookCode"].ToString(),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Price = Convert.ToInt32(reader["Price"]),
                                Genre = reader["Genre"].ToString()
                            };

                            books.Add(book);
                        }
                    }
                }
            }
            //Return list employees
            return books;
        }

        //Update
        public async Task UpdateBookAsync(string BookCode, Book updatedbook)
        {
            // Open a database connection
            using (SqlConnection con = SqlServerConnectionManager.OpenConnection(WindowconnString))
            {
                // SQL query to update an employee's details
                string query = "UPDATE Library SET BookCode=@BookCode,Title=@Title, Author=@Author,Genre=@Genre, Price=@Price" +
                               " WHERE BookCode=@bookCode";

                // Prepare the SQL command with the query and connection
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add parameters for the update query
                    command.Parameters.AddWithValue("@bookCode", BookCode);
                    command.Parameters.AddWithValue("@BookCode", updatedbook.BookCode);
                    command.Parameters.AddWithValue("@Title", updatedbook.Title);
                    command.Parameters.AddWithValue("@Author", updatedbook.Author);
                    command.Parameters.AddWithValue("@Genre", updatedbook.Genre);
                    command.Parameters.AddWithValue("@Price", updatedbook.Price);

                    // Execute the update command asynchronously
                    await command.ExecuteNonQueryAsync();

                    // Confirm successful update
                    Console.WriteLine("Book Updated Successfully.");
                }
            }
        }

        public async Task<Book> GetBookByCodeAsync(string bookCode)
        {
            // Open a database connection
            using (SqlConnection con = SqlServerConnectionManager.OpenConnection(WindowconnString))
            {
                // SQL query to select an employee by their code
                string query = "SELECT * FROM Library WHERE BookCode=@BookCode";

                // Prepare the SQL command with the query and connection
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Add the employee code parameter
                    command.Parameters.AddWithValue("@BookCode", bookCode);

                    // Execute the query and get a data reader
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Check if a record was found
                        if (await reader.ReadAsync())
                        {
                            // Map the data to an EMPLOYEE object and return it
                            return new Book
                            {
                                BookCode = reader["BookCode"].ToString(),
                                Title = reader["Title"].ToString(),
                                Author= reader["Author"].ToString(),
                                Price = Convert.ToInt32(reader["Price"]),
                                Genre = reader["Genre"].ToString()
                            };
                        }
                        // Return null if no record was found
                        return null;
                    }
                }
            }
        }


    }
}
