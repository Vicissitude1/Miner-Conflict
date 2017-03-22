﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MinerConflict.Builders;
using MinerConflict.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    class Base:Component, IUpdate
    {
        private bool[] notClicked;

        public Base(GameObject gameObject) : base(gameObject)
        {
            notClicked = new bool[2];
            for (int i = 0; i > notClicked.Length; i++) { notClicked[i] = true; }
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
                    //Spawn another pikeman
                }
                notClicked[1] = false;
            } else
            {
                notClicked[1] = true;
            }
        }
    }
}
