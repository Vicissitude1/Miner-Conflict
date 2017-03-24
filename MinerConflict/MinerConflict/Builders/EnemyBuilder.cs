using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MinerConflict.Builders
{
    class EnemyBuilder : IBuilder
    {
        private GameObject gameObject;

        public void Buildpart(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new SpriteRenderer(gameObject, Globals.Graphics.PikemanWalkBlueTexture, 1f, 1.5f));
            gameObject.AddComponent(new Animator(gameObject));
            gameObject.AddComponent(new Collider(gameObject, 0.6f));
            gameObject.AddComponent(new Enemy(50, 1, gameObject));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
