using FurnaceRefactored.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceRefactored.Client
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "args")]
        static void Main(string[] args)
        {
            int minTemp = 65;
            int maxTemp = 68;
            int temp;
            string cmd = "";

            // NOTE: Here are the new class instantiations...
            IThermometerService thermometer = new ThermometerService();
            IFurnaceService furnace = new FurnaceService();
            IThermostat thermostat = new Thermostat();

            Console.WriteLine("Enter any key to quit");
            Console.WriteLine("====================");
            Console.WriteLine("Min Temperature: " + minTemp);
            Console.WriteLine("Max Temperature: " + maxTemp);
            Console.WriteLine();

            while (String.IsNullOrEmpty(cmd))
            {
                // NOTE: Here is the old class instantiations...
                //Thermostat thermostat = new Thermostat();
                temp = thermostat.Regulate(minTemp, maxTemp, thermometer, furnace); // injecting the service instances via the method

                cmd = Console.ReadLine();
            }
        }
    }
}
