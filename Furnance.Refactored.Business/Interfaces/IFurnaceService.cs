using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnaceRefactored.Business
{
    public interface IFurnaceService
    {
        bool IsOn {get;}
        void TurnOn();
        void TurnOff();
    }
}
