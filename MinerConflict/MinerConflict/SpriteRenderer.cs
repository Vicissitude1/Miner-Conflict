using Microsoft.Xna.Framework;
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
        private Rectangle rectangle;
        public SpriteEffects spriteEffect { get; set; }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public SpriteRenderer(GameObject gameObject, Texture2D sprite, float layer) : base(gameObject)
        {
            this.layer = layer;
            this.sprite = sprite;
            this.spriteEffect = SpriteEffects.None;
            this.rectangle = sprite.Bounds;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, gameObject.transform.Position, rectangle, Color.White, 0, Vector2.Zero, gameObject.scaleFactor, spriteEffect, layer);
        }
    }
}
