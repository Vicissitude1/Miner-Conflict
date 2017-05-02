using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLow
{
    public class Dice : IDice
    {
        private Random rnd;

        public int Roll()
        {
            int a;
            rnd = new Random();
            a = rnd.Next(1, 6);
            return a;
        }
    }
}
