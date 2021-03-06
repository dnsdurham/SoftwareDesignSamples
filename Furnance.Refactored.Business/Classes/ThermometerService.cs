﻿using HardwareApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceRefactored.Business
{
    public class ThermometerService : IThermometerService
    {
        public int CurrentTemperature
        {
            get
            {
                // class will interface with an external hardware device
                return ThermometerHardware.Temp;
            }
        }
    }
}
