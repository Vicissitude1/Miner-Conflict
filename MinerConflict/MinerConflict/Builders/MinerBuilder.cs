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
            gameObject = new GameObject(new Vector2(200, 200));
            gameObject.AddComponent(new SpriteRenderer(gameObject, Globals.Graphics.MineBuildingTexture, 1f, 0.5f));
            gameObject.AddComponent(new Mine(gameObject));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
