using HardwareApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceClassic.Business
{
    class FurnaceService
    {
        public bool IsOn 
        { 
            get 
            { 
                // return the current state from the hardware device
                return FurnaceHardware.IsOn; 
            } 
        }

        // these methods interface with a physical device for controlling the furnace operations.
        public void TurnOn()
        {
            FurnaceHardware.TurnOn();
        }

        public void TurnOff()
        {
            FurnaceHardware.TurnOff();
        }
    }
}
