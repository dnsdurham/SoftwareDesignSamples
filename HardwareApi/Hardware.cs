using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareApi
{
    public static class FurnaceHardware
    {
        private static bool _isOn = false;
        public static bool IsOn { get { return _isOn; } }

        public static void TurnOn()
        {
            _isOn = true;
        }

        public static void TurnOff()
        {
            _isOn = false;
        }
    }

    public static class ThermometerHardware
    {
        private static int _currentTemp = new Random().Next(60, 70);

        public static int Temp 
            {
                get
                {
                    if (FurnaceHardware.IsOn)
                    {
                        return ++_currentTemp; 
                    }
                    else
                    {
                        return --_currentTemp;
                    }
                }
            }
    }
}
