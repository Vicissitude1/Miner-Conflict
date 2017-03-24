using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict.Builders
{
    class YouWonBuilder:IBuilder
    {
        private GameObject gameObject;

        public void Buildpart(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new SpriteRenderer(gameObject,Globals.Graphics.YouWonTexture,1f,1f));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
