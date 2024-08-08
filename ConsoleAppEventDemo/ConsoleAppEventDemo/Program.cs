namespace ConsoleAppEventDemo
{
    //1-Defining delegate
    public delegate string WelcomeDelegate(string username);
    public class Program
    {
        //2-Declaring an event using EventHandler(Delegate)
        //Event Handling requires delegate implementation
        //to dispatch events
        event WelcomeDelegate WelcomeEvent;
        public Program()
        {
            //3-Attaching method or function to the event
            WelcomeEvent += new WelcomeDelegate(this.Welcome);
        }
        static void Main(string[] args)
        {

            //4.Invoking -dispatching
            Program myprogram = new Program();
            string result = myprogram.WelcomeEvent("Gatha");
            Console.WriteLine(result);
            Console.ReadKey();
            
        }
        // simple method
        public string Welcome(string username)
        {
            return "You are logged as :" + username;
        }
    }
}
