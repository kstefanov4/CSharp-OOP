using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentityable> enters = new List<IIdentityable>();
            while (input != "End")
            {
                string[] infoArray = input.Split();

                if (infoArray.Length == 3)
                {
                    IIdentityable citizen = new Citizen(infoArray[0],int.Parse(infoArray[1]), infoArray[2]);
                    enters.Add(citizen);
                }
                else
                {
                    IIdentityable robot = new Robot(infoArray[0], infoArray[1]);
                    enters.Add(robot);
                }
                input = Console.ReadLine();
            }
            string controlNumber = Console.ReadLine();

            var rebellions = enters.Where(x => x.ID.EndsWith(controlNumber)).ToList();

            foreach (var rebellion in rebellions)
            {
                Console.WriteLine(rebellion.ID);
            }
        }
    }
}
