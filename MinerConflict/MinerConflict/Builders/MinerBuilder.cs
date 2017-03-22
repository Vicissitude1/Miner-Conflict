using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict.Builders
{
    class MinerBuilder : IBuilder
    {
        private GameObject gameObject;

        public void Buildpart(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new SpriteRenderer(gameObject, Globals.Graphics.MinerWalkTexture, 1f, 1.5f));
            gameObject.AddComponent(new Animator(gameObject));
            gameObject.AddComponent(new Miner(50, 0, gameObject));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
