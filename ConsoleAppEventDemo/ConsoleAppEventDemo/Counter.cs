using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEventDemo
{
    //define delegqate
    public delegate void TemperatureDelegate(float temperature);
    public class Counter
    {
        //defining event
        event TemperatureDelegate TemperatureEvent;
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Console.WriteLine("Enter the temperature");
            float temperature = float.Parse(Console.ReadLine());
            
            //attaching event
            counter.TemperatureEvent += counter.CheckTemp;
            if (temperature < 0 || temperature > 100)
            {

                counter.TemperatureEvent(temperature);

            }
            else {
                Console.WriteLine($"The temperature is {temperature}");
                }
            Console.ReadKey();

        }
        public void CheckTemp(float temperature)
        {
            Console.WriteLine("Critical temperature reached");
        }

        
        //another code for third question by sir
   /*      using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemparatureEventHandler
    {
        //1 define Delegate
        public delegate void CriticalTemperatureEventHandler(string message);

        public class TemparatureSensor
        {
            //Field
            private int _temparature;

            //2  Event for critical temparature
            event CriticalTemperatureEventHandler CriticalTemperature;


            //setter
            public int Temparature
            {
                get { return _temparature; }
                set
                {
                    _temparature = value;

                    if (_temparature > 100 || _temparature < 0)
                    {
                        //Raise the event
                        OnTemparatureMessage($"Critical temperature reached: {_temparature}");

                    }
                    else
                    {
                        OnTemparatureMessage($"Normal temperature reached: {_temparature}");
                    }

                }
            }

            //  3  method to raise the event-- publisher
            //to display the message after finding normal or critical
            protected virtual void OnTemparatureMessage(string message)
            {
                //event -- attach the event 
                CriticalTemperature?.Invoke(message);
            }

            static void Main(string[] args)
            {
                //create an object
                TemparatureSensor temparatureSensor = new TemparatureSensor();

                //suscribe to the temperature event  - suscriber
                temparatureSensor.CriticalTemperature += Sensor_CriticalTemperatureReached;

                //Simulate temperature changes
                temparatureSensor.Temparature = 100;
                temparatureSensor.Temparature = 12;
                temparatureSensor.Temparature = -30;
                temparatureSensor.Temparature = 110;
                Console.ReadKey();
            }

            private static void TemparatureSensor_CriticalTemperature(string message)
            {
                throw new NotImplementedException();
            }


            //Method for delegate
            private static void Sensor_CriticalTemperatureReached(string message)
            {
                Console.WriteLine(message);
            }
        } 
    } */

}
   
}
