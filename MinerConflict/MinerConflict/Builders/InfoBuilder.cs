using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MinerConflict.Interfaces;

namespace MinerConflict.Builders
{
    class InfoBuilder:IBuilder
    {
        private GameObject gameObject;

        public void Buildpart(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new Info(gameObject));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
