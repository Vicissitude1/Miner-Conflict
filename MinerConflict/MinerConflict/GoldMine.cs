using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MinerConflict
{
    class GoldMine : Component
    {
        private object thisLock = new Object();
        private int amountCollected;
        private bool working;


        private int goldAmount;

        public GoldMine(GameObject gameObject, int goldAmount) : base(gameObject)
        {
            this.goldAmount = goldAmount;
            working = false;

        }


        public int Collect(int amount)
        {
            lock (thisLock)
            {
                if (amount > goldAmount)
                {
                    Thread.Sleep(1500);
                    int whatsLeft = goldAmount;
                    goldAmount = 0;
                    return whatsLeft;
                }
                else
                {
                    Thread.Sleep(1500);
                    goldAmount -= amount;
                    return amount;
                }
            }
        }

    }
}
