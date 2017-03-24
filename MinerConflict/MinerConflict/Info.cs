using MinerConflict.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace MinerConflict
{
    class Info:Component, IUpdate, IDrawable, ILoadeble
    {
        private int gold;
        private object goldLock = new object();
        private string x;
        private SpriteFont font;
        

        public Info(GameObject gameObject) : base(gameObject)
        {
            x = null;
        }

        public void Update()
        {
            x = "Gold: " + gold + "\n\nPress M - Miner cost: 150\nPress P - Pikeman cost: 250";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (x != null)
            {
                spriteBatch.DrawString(font, x, new Vector2(400, 300), Color.Black);
            }
        }

        public bool TransactGod(int amount)
        {
            lock (goldLock)
            {
                if (amount < 0)
                {
                    if (gold + amount < 0)
                    {
                        return false;
                    } else
                    {
                        gold += amount;
                        return true;
                    }
                } else
                {
                    gold += amount;
                    return true;
                }
            }

        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font2");
        }
    }
}
