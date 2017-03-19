﻿using Microsoft.Xna.Framework;

namespace MinerConflict
{
    class Transform:Component
    {
        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Transform(GameObject gameObject, Vector2 position) : base(gameObject)
        {
            this.position = position;
        }

        public void Translate(Vector2 translation)
        {
            position += translation;
        }
    }
}