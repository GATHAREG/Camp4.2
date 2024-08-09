using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemoFileHandling
{
    public class CopyingFile
    {
        static void Main(string[] args)
        {
            try
            { //esource file is given

                string filepath = "firstFile.txt";

                //if file exists then prompts user to enter destination file
                if (File.Exists(filepath))
                {
                    Console.WriteLine("Enter the destination of file to be copied");
                    string destination=Console.ReadLine();

                    //if that file already exists, over write
                    
                    if (File.Exists(destination))
                    {
                        Console.WriteLine("file already exists");
                    }
                    //inbuilt function to copy from source to destination 
                    //setting true to overwritw if already exists
                    File.Copy(filepath, destination ,true);
                    Console.WriteLine("File copied sucessfully");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
