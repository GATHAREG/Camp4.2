using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemoFileHandling
{
    public class FiveCharacterRetrieval
    {
        static void Main(string[] args)
        {


            try
            {
                string filePath = "demo.txt";
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                if (File.Exists(filePath))
                {

                    StreamReader sReader = new StreamReader(fs);
                    string line=sReader.ReadToEnd();



                    if (line.Length >= 7) 
                    {
                        // start from the third character (index 2)
                        for (int i = 2; i < 7; i++) 
                        {
                            Console.WriteLine(line[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The file does not have enough characters.");
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
