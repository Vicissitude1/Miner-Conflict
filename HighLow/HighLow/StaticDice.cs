using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLow
{
    public class StaticDice : IDice
    {
        int roll;

        public StaticDice(int roll)
        {
            this.roll = roll;
        }
        public int Roll()
        {

            return roll;
        }
    }
}
