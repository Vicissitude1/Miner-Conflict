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
        private Info info;

        public Base(GameObject gameObject) : base(gameObject)
        {
            notClicked = new bool[3];
            for (int i = 0; i > notClicked.Length; i++) { notClicked[i] = true; }
            MySemaphore.Release(4);
        }

        public void Update()
        {
            //20 150 miner
            KeyboardState x = Keyboard.GetState();
            if (info == null)
            {
                if (GameWorld.Instance.GameObjects.Exists(g => g.GetComponent("Info") is Info))
                {
                    GameObject temp = GameWorld.Instance.GameObjects.Find(g => g.GetComponent("Info") is Info);
                    info = (temp.GetComponent("Info") as Info);
                }
            } else
            {
                if (x.IsKeyDown(Keys.M))
                {
                    if (notClicked[0])
                    {
                        if (info.TransactGod(-150))
                        {
                            Director dir = new Director(new MinerBuilder());
                            GameWorld.Instance.AddUnit(dir.Construct(new Vector2(20, 120)));
                        }
                    }
                    notClicked[0] = false;
                } else { notClicked[0] = true; }
                if (x.IsKeyDown(Keys.P))
                {
                    if (notClicked[1])
                    {
                        if (info.TransactGod(-250))
                        {
                            Director dir = new Director(new PikemanBuilder());
                            GameWorld.Instance.AddUnit(dir.Construct(new Vector2(160, 30)));
                        }
                    }
                    notClicked[1] = false;
                } else
                {
                    notClicked[1] = true;
                }
#if DEBUG
                if (x.IsKeyDown(Keys.G))
                {
                    if (notClicked[2])
                    {
                        if (info.TransactGod(100))
                        {
                        }
                    }
                    notClicked[2] = false;
                } else
                {
                    notClicked[2] = true;
                }
#endif
            }
        }

        public int Deposit(int collected)
        {

            MySemaphore.WaitOne();
            Thread.Sleep(3000);
            while (true)
            {
                if (info.TransactGod(collected))
                {
                    collected = 0;
                    break;
                }
            }
            MySemaphore.Release();
            return collected;
        }
    }
}
