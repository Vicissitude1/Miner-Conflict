﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MinerConflict
{
    class GoldMine : Component
    {
        private static Object thisLock = new Object();
        private string instance = null;
        private int amountCollected;
        private bool working;

        private int goldAmount;

        public GoldMine(GameObject gameObject, int goldAmount) : base(gameObject)
        {
            this.goldAmount = goldAmount;
            working = false;

            if(instance == null)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Collect));
                t.IsBackground = true;
                t.Start(15);
               

            }
        }

        public void Collect(object obj)
        {
            while (working == true)
            {

                int amount = (int)obj;
                lock (thisLock)
                    if (amount > goldAmount)
                    {
                        amount = 1;
                        Thread.Sleep(1500);
                        goldAmount =- amount;
                        working = false;

                    }
                    else
                    {

                        Thread.Sleep(1500);
                        goldAmount =- amount;
                        working = false;


                    }
            }
        }

    }
}
