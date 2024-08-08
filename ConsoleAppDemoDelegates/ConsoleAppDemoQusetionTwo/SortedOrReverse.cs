namespace ConsoleAppDemoDelegates
{
     //initializing delegate
    public delegate int[] DelegateArray(int[] array);
    public class SortedOrReverse

    {
        
        static void Main(string[] args)

        {
            //creating object
            SortedOrReverse obj = new SortedOrReverse();
          
            Console.WriteLine("The application to reverse or sort Array");
            Console.WriteLine("Enter the array size:");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the array elements");
            int[] arr = new int[size];  
            for (int i = 0; i < size; i++) 
            {
                arr[i] = int.Parse(Console.ReadLine());
            
            }
            //instantiating the delegate
            DelegateArray delearray = new DelegateArray(obj.Sorted);
            Console.WriteLine("Select the choice of operation to perform in Array\n 1.Sort\n 2.Reverse");
            Console.WriteLine("Enter the choice");
            
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {

               //invoking sorted
                delearray.Invoke( arr);

            }
            else if(n == 2)
            {
              // invoking reverse
                delearray += obj.Reverse;
                delearray -= obj.Sorted;
                delearray.Invoke( arr);
            }
           
        }
        public int[] Sorted(int[] arr)
        {
           
                Array.Sort(arr);
            foreach(int num in arr)
           {
               Console.WriteLine(num);
           }
            return arr;

           
        }
        public int[] Reverse(int[] arr)
        {
            Array.Reverse(arr);
            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }


                    return arr;
        }
    }
}
