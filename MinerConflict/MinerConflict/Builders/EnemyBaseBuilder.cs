﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict.Builders
{
    class EnemyBaseBuilder : IBuilder
    {
        private GameObject gameObject;
        public void Buildpart(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new SpriteRenderer(gameObject, Globals.Graphics.BaseBuildingTexture, 1f, 0.5f));
            gameObject.AddComponent(new EnemyBase(gameObject));
            gameObject.AddComponent(new Collider(gameObject, 0));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
