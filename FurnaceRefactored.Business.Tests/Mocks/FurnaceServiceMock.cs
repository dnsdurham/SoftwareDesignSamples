using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceRefactored.Business.Tests
{
    public class FurnaceServiceMock : IFurnaceService
    {
        private bool _isOn = false;

        public bool IsOnOverride // use this to manually set the desired furnace state
        {
            set
            { 
                _isOn = value; 
            } 
        }

        public bool IsOn
        {
            get 
            { 
                return _isOn; 
            }
        }

        public void TurnOn()
        {
            _isOn = true;
        }

        public void TurnOff()
        {
            _isOn = false;
        }
    }
}
