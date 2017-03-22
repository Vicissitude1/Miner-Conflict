using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MinerConflict.Interfaces;

namespace MinerConflict
{
    class Pikeman : Component, IUpdate, ILoadeble
    {
        private string instance;
        public Animator animator;
        public int health;
        public DIRECTION direction;
        public int damege;

        public Pikeman(int health, int damege, GameObject gameObject) : base(gameObject)
        {
            this.health = health;
            this.damege = damege;
        }

      

        public void Update()
        {
           
        }

        public void LoadContent(ContentManager content)
        {
            animator = (Animator)gameObject.GetComponent("Animator");
            direction = DIRECTION.Left;

            animator.CreateAnimation("WalkLeft", new Animation(8, 0, 0, 100, 80, 8f, new Vector2(-50, 10)));
            animator.PlayAnimation("WalkLeft");
        }
    }
}
