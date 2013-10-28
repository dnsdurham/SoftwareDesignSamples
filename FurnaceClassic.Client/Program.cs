using FurnaceClassic.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceClassic.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int minTemp = 65;
            int maxTemp = 68;
            int temp;
            string cmd = "";

            Console.WriteLine("Enter any key to quit");
            Console.WriteLine("====================");
            Console.WriteLine("Min Temperature: " + minTemp);
            Console.WriteLine("Max Temperature: " + maxTemp);
            Console.WriteLine();

            while (cmd == "")
            {
                Thermostat thermostat = new Thermostat();
                temp = thermostat.Regulate(minTemp, maxTemp);

                cmd = Console.ReadLine();
            }
        }
    }
}
