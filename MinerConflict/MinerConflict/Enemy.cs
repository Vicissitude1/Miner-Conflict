using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MinerConflict.Interfaces;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace MinerConflict
{
    class Enemy : Component, IUpdate, ILoadeble
    {
        public Animator animator;
        public int health;
        private Semaphore healthLock= new Semaphore(0, 4);
        public DIRECTION direction;
        public int damege;
        public bool canwalk;
        private bool checkedForGraphics;

        public Enemy(int health, int damege, GameObject gameObject) : base(gameObject)
        {
            this.health = health;
            this.damege = damege;
            canwalk = true;
            checkedForGraphics = false;
            healthLock.Release(4);
        }



        public void Update()
        {
            if (!checkedForGraphics)
            {
                (gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).spriteEffect = SpriteEffects.FlipHorizontally;
                (gameObject.GetComponent("Collider") as Collider).offRect = new Vector2(80, 0);
                checkedForGraphics = true;
            }
            if (canwalk)
            {
                gameObject.transform.Translate(new Vector2(-30 * GameWorld.Instance.deltaTime, 0));
            }
            if (health <= 0)
            {
                GameWorld.Instance.RemoveUnit(gameObject);
            }
        }

        public void LoadContent(ContentManager content)
        {
            animator = (Animator)gameObject.GetComponent("Animator");
            direction = DIRECTION.Left;

            animator.CreateAnimation("WalkLeft", new Animation(8, 0, 0, 100, 80, 8f, new Vector2(-50, 10)));
            animator.PlayAnimation("WalkLeft");
        }

        public void TakeDamage(int dmg)
        {
            healthLock.WaitOne();
            health -= dmg;
            healthLock.Release();
        }
    }
}
