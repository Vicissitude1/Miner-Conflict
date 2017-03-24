using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MinerConflict.Builders;
using MinerConflict.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MinerConflict
{
    class Base:Component, IUpdate
    {
        private bool[] notClicked;
        private Semaphore MySemaphore = new Semaphore(0, 4);
        private static int amount = 0;

        public Base(GameObject gameObject) : base(gameObject)
        {
            notClicked = new bool[2];
            for (int i = 0; i > notClicked.Length; i++) { notClicked[i] = true; }
            MySemaphore.Release(4);
        }

        public void Update()
        {
            //20 150 miner
            KeyboardState x = Keyboard.GetState();
          

            if (x.IsKeyDown(Keys.M))
            {
                if (notClicked[0])
                {
                    Director dir = new Director(new MinerBuilder());
                    GameWorld.Instance.AddUnit(dir.Construct(new Vector2(20, 120)));
                }
                notClicked[0] = false;
            } else { notClicked[0] = true; }
            if (x.IsKeyDown(Keys.P))
            {
                if (notClicked[1])
                {
                    Director dir = new Director(new PikemanBuilder());
                    GameWorld.Instance.AddUnit(dir.Construct(new Vector2(160, 30)));
                }
                notClicked[1] = false;
            } else
            {
                notClicked[1] = true;
            }
        }

        public int Deposit(int collected)
        {

            MySemaphore.WaitOne();
            Thread.Sleep(3000);
            amount += collected;
            collected = 0;
            MySemaphore.Release();
            return collected;
        }
    }
}
