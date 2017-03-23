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
        public float scaleFactor { get; private set; }
        public SpriteEffects spriteEffect { get; set; }
        public Color colour { get; set; }

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

        public SpriteRenderer(GameObject gameObject, Texture2D sprite, float layer, float scaleFactor) : base(gameObject)
        {
            this.layer = layer;
            this.sprite = sprite;
            this.spriteEffect = SpriteEffects.None;
            this.rectangle = sprite.Bounds;
            this.scaleFactor = scaleFactor;
            this.colour = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, gameObject.transform.Position, rectangle, colour, 0, Vector2.Zero, scaleFactor, spriteEffect, layer);
        }
    }
}
