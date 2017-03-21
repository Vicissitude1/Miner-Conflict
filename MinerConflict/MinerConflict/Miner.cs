using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MinerConflict.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MinerConflict
{
    class Miner : SpeedUpgrade, IUpdate, ILoadeble
    {


        private static Object thisLockMiner = new Object();
        private string instance;
        public Animator animator;
        public int health;
        public DIRECTION direction;
        private int collected;

        public Miner ( int health, int collected)
        {
            this.health = health;
            this.collected = collected;


        }

        public void Update()
        {

        }

        public void Move(object obj)
        {
            
        }


        public void LoadContent(ContentManager content)
        {

            animator = (Animator)gameObject.GetComponent("Animator");

            direction = DIRECTION.Left;

            animator.CreateAnimation("WalkLeft", new Animation(4, 65, 4, 61, 48, 6, Vector2.Zero));           

            animator.PlayAnimation("WalkLeft");
        }



    }
}
