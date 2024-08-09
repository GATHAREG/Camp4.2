using System.IO;
    namespace ConsoleAppDemoFileHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Writing data into Text file and reading it into console
            try  
            { 
                //Specify file name  
                string fileName = "demo1.txt";
                // 3arguments to be passed filename,mode of opening,accessing for what
                //Create Filestream to open the file in file mode
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate,FileAccess.Write);
                //Create streamWriter
                StreamWriter swriter = new StreamWriter(fs);
                swriter.WriteLine("This is Sample Data entered by Gatha");

                //close streamwriter
                swriter.Close();
                Console.WriteLine("File creation Sucessful");

                // Reading a file
                try
                {
                    //check file exists
                    if(File.Exists(fileName))
                    {
                        FileStream fStream = new FileStream(fileName,FileMode.Open,FileAccess.Read);
                        StreamReader sReader = new StreamReader(fStream);
                        string data = string.Empty;
                        data= sReader.ReadToEnd();

                        //printing it on the console
                        Console.WriteLine(data);
                        sReader.Close();
                        Console.WriteLine("File Reading is success");

                    }
                    else
                    {
                        Console.WriteLine("File not found!........");
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
            finally
            {
                Console.WriteLine("Thanks for choosing");
            }
        }
    }
}
