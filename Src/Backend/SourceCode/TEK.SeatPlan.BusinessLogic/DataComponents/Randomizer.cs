using System;
using TEK.SeatPlan.BusinessLogic.Contract;

namespace TEK.SeatPlan.BusinessLogic.DataComponents
{
    public class Randomizer : DataComponentBase, IRandomizer
    {
        private readonly Random randomGen = new Random();

        public int Next(int minValue, int maxValue)
        {
            return randomGen.Next(minValue, maxValue);
        }
    }
}
