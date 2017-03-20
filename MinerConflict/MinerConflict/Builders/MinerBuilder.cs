using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict.Builders
{
    class MinerBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject(Vector2 position)
        {
            gameObject = new GameObject();
            gameObject.AddComponent(new SpriteRenderer(gameObject, "MinerUnit", 1));
        }
    }
}
