using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEK.SeatPlan.BusinessLogic.Contract
{
    public interface IRandomizer
    {
        int Next(int minValue, int maxValue);
    }
}
