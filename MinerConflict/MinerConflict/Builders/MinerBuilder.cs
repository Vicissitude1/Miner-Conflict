﻿using Microsoft.Xna.Framework;
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

        public void Buildpart(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new SpriteRenderer(gameObject, Globals.Graphics.MinerUnitTexture, 1f, 0.6f));
            gameObject.AddComponent(new Miner(50, 0));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
