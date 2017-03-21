using System;
using MinerConflict.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MinerConflict
{
    class UpdateTester:Component, IUpdate
    {
        public UpdateTester(GameObject gameObject) : base(gameObject)
        {
        }

        public void Update()
        {
            if ((gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).spriteEffect != SpriteEffects.FlipVertically)
            {
                (gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).spriteEffect = SpriteEffects.FlipVertically;
            }
        }
    }
}
