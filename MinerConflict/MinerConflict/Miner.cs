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
        private GameObject assocBase;
    

        public Miner ( int health, GameObject gameObject) : base(gameObject)
        {
            this.health = health;
            this.collected = 0;
            
        }

        public void Update()
        {
            if (assocMine == null && assocBase == null)
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
                if (assocBase == null)
                {
                    foreach (GameObject obj in GameWorld.Instance.GameObjects)
                    {
                        if (obj.GetComponent("Base") is Base)
                        {
                            assocBase = obj;
                            break;
                        }
                    }
                }
            } else
            {
                if (gameObject.transform.Position.Y < assocMine.transform.Position.Y && collected <= 0)
                {
                    Vector2 translation = assocMine.transform.Position - gameObject.transform.Position;
                    translation.Normalize();
                    gameObject.transform.Translate(translation * GameWorld.Instance.deltaTime * 40/*speed*/);
                } else if (collected <= 0)
                {
                    collected = 50; //change this later
                } else if (gameObject.transform.Position.Y > assocBase.transform.Position.Y && collected > 0)
                {
                    Vector2 translation = assocBase.transform.Position - gameObject.transform.Position;
                    translation.Normalize();
                    gameObject.transform.Translate(translation * GameWorld.Instance.deltaTime * 40/*speed*/);
                } else
                {
                    collected = 0;
                }
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
