using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MinerConflict.Builders;
using MinerConflict.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MinerConflict
{
    class EnemyBase:Component, IUpdate
    {
        private bool checkedForGraphics;
        private float time;
        private int health;
        private Mutex healthLock = new Mutex();

        public EnemyBase(GameObject gameObject) : base(gameObject)
        {
            checkedForGraphics = false;
            time = 30;
            health = 2000;
            
        }

        public void Update()
        {
            if (!checkedForGraphics)
            {
                (gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).spriteEffect = SpriteEffects.FlipHorizontally;
                (gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).colour = Color.Multiply(Color.Red, 1f);
                checkedForGraphics = true;
            }
            time -= GameWorld.Instance.deltaTime;
            if (time <= 0)
            {
                time = 15;
                Debug.WriteLine("Unit build!");
            }
            if (health <= 0)
            {
                GameWorld.Instance.RemoveUnit(gameObject);
            }
        }

        public void TakeDamage(int dmg)
        {
            healthLock.WaitOne();
            health -= dmg;
            healthLock.ReleaseMutex();
        }
    }
}
