using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceClassic.Business
{
    public class Thermostat
    {
        public int Regulate(int minTemp, int maxTemp)
        {
            // the goal is to turn the furnace on once the temperarture has dropped to a certain level (minTemp) 
            // and then leave it on until the temperature has increased to a max level (maxTemp)
         
            ThermometerService thermometer = new ThermometerService();
            FurnaceService furnace = new FurnaceService();

            int currentTemp = thermometer.CurrentTemperature;
            Trace.WriteLine("Current temp: " + currentTemp);

            if (furnace.IsOn == false)
            {
                if (currentTemp < minTemp)
                {
                    // turn the furnace on if we are below the min temp
                    furnace.TurnOn();
                    Trace.WriteLine("Furnace turned on");
                }
            }
            else // furnace is on
            {
                if (currentTemp == maxTemp)
                {
                    // turn the furnace off if we have reached the max temp
                    furnace.TurnOff();
                    Trace.WriteLine("Furnace turned off");
                }
            }

            return currentTemp;
        }
    }
}
