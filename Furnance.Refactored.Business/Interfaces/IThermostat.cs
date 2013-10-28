using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceRefactored.Business
{
    public interface IThermostat
    {
        // inject the service dependencies via the method call
        int Regulate(int minTemp, int maxTemp, IThermometerService thermometer, IFurnaceService furnace);
    }
}
