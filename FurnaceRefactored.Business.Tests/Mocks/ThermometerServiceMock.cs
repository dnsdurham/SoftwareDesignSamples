using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceRefactored.Business.Tests
{
    public class ThermometerServiceMock : IThermometerService
    {
        private int _temp;
        public int TempOverride // use this to manually set the desired temperature
        {
            set
            { 
                _temp = value; 
            } 
        } 
        public int CurrentTemperature
        {
            get 
            { 
                return _temp; 
            }
        }
    }
}
