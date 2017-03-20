using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    class GoldMine : Component
    {

        private int goldAmount;

        public GoldMine(GameObject gameObject, int goldAmount) : base(gameObject)
        {
            this.goldAmount = goldAmount;
        }


    }
}
