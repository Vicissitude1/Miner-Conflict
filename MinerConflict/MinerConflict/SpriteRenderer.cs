﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    class SpriteRenderer:Component, IDrawable
    {

        private float layer;
        private Texture2D sprite;
        private Vector2 offset;

        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public SpriteRenderer(GameObject gameObject, Texture2D sprite, float layer) : base(gameObject)
        {
            this.layer = layer;
            this.sprite = sprite;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
        }
    }
}