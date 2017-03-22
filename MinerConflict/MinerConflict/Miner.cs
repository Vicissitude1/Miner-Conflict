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
        private GameObject assocMine;
        private GameObject minerpos;
    

        public Miner ( int health, int collected, GameObject gameObject):base(gameObject)
        {
            this.health = health;
            this.collected = collected;
            
        }

        public void Update()
        {
            if (assocMine == null)
            {
                foreach (GameObject obj in GameWorld.Instance.GameObjects)
                {
                    if (obj.GetComponent("GoldMine") is GoldMine)
                    {
                        assocMine = obj;
                        break;
                    }
                }
            }

            if (minerpos.transform.Position.X >= assocMine.transform.Position.X || minerpos.transform.Position.Y >= assocMine.transform.Position.Y)
            {

                //gameObject.transform.Position.X += 0;
                //gameObject.transform.Position.Y += -10;
                gameObject.transform.Translate(new Vector2(0, +10 * GameWorld.Instance.deltaTime));
            }
            else if (collected > 0)
            {
                gameObject.transform.Translate(new Vector2(0, -10 * GameWorld.Instance.deltaTime));

            }
            else
            {
                gameObject.transform.Translate(new Vector2(0, 0 * GameWorld.Instance.deltaTime));
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
            animator.CreateAnimation("WalkLeft", new Animation(6, 0, 0, 50, 58, 6f, new Vector2(-50,10)));
            animator.PlayAnimation("WalkLeft");
        }



    }
}
