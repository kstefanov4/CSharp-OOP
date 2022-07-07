using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>(Console.ReadLine().Split().ToList());
            List<string> urls = new List<string>(Console.ReadLine().Split().ToList());

            Smartphone smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Brawse(url));
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
