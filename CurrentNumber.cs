using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    internal class CurrentNumber
    {
        public int Value { get; set; }
        public string Color  { get; set; }

        public CurrentNumber(int val, string color)
        {
            Value = val;
            Color = color;
        }
    }
}
