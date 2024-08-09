using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemoFileHandling
{
    public class AppendingText
    {
        static void Main(string[] args)
        {

            try
            {
                string filePath = "demo.txt";
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                if(File.Exists(filePath))
                {
                    string text = "Hello all.";
                    StreamWriter writer = new StreamWriter(fs);
                    writer.WriteLine(text);
                    Console.WriteLine("Text added ");

                    writer.Close();
                    try
                    {
                       FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        StreamReader sReader = new StreamReader(fStream);
                      
                      


                        string data = File.ReadAllText(filePath);

                        Console.WriteLine(data);
                        sReader.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
               
            


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
