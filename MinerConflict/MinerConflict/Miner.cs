using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    class Miner : SpeedUpgrade
    {
        
        public Animator animator;
        public int health;
        public DIRECTION direction;
        private double cycles;
        private int collected;

        public Miner ( int health, int collected)
        {
            this.health = health;
            this.collected = collected;
            
        }


    }
}
