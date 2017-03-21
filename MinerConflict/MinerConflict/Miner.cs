using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MinerConflict
{
    class Miner : SpeedUpgrade
    {

        private static Object thisLockMiner = new Object();
        private string instance;
        public Animator animator;
        public int health;
        public DIRECTION direction;
        private double cycles;
        private int collected;

        public Miner ( int health, int collected)
        {
            this.health = health;
            this.collected = collected;

            if (instance == null)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Move));
                t.IsBackground = true;
                t.Start(15);
            }

        }

        public void Update()
        {

        }

        public void Move(object obj)
        {
            
        }

        




    }
}
