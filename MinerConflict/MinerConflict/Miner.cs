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

        public Miner ( int health, int collected, GameObject gameObject) : base(gameObject)
        {
            this.health = health;
            this.collected = collected;
        }

        public void Update()
        {
            if(collected > 0)
            {
               
                gameObject.transform.Translate(new Vector2(0, -10));
            }
            else if(collected <= 0)
            {
                gameObject.transform.Translate(new Vector2(0, +10));

            }
            
        }

        public void Move(object obj)
        {
            
        }

        public void LoadContent(ContentManager content)
        {

            animator = (Animator)gameObject.GetComponent("Animator");
            direction = DIRECTION.Left;

         // animator.CreateAnimation("WalkLeft", new Animation(4, 64, 4, 61, 48, 1, Vector2.Zero));           
            animator.CreateAnimation("WalkLeft", new Animation(6, 0, 0, 50, 58, 1f, new Vector2(-50,10)));
            animator.PlayAnimation("WalkLeft");
        }



    }
}
