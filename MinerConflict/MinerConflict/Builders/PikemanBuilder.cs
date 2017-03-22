using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MinerConflict.Builders
{
    class PikemanBuilder : IBuilder
    {
        private GameObject gameObject;

        public void Buildpart(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new SpriteRenderer(gameObject, Globals.Graphics.PikemanWalkTexture, 1f, 1.5f));
            gameObject.AddComponent(new Animator(gameObject));
            gameObject.AddComponent(new Pikeman(50, 10, gameObject));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }


    }
}
