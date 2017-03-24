﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinerConflict.Interfaces;

namespace MinerConflict
{
    class Collider:Component, IDrawable, ILoadeble, IUpdate
    {
        private SpriteRenderer spriteRenderer;
        private Texture2D texture;
        public bool doCollisionCheck { private get; set; }
        private List<Collider> otherColliders;
        private float centerPercent;
        public string ownerType;
        private Component assocType;

        public Collider(GameObject gameObject, float centerPercent) : base(gameObject)
        {
            this.spriteRenderer = (gameObject.GetComponent("SpriteRenderer") as SpriteRenderer);
            GameWorld.Instance.Colliders.Add(this);
            this.otherColliders = new List<Collider>();
            this.centerPercent = centerPercent;
        }

        public Rectangle GetCollisionBox
        {
            get
            {
                if (centerPercent == 0)
                {
                    return new Rectangle
                    (
                        (int)(gameObject.transform.Position.X + spriteRenderer.Offset.X),
                        (int)(gameObject.transform.Position.Y + spriteRenderer.Offset.Y),
                        (int)(spriteRenderer.Rectangle.Width * spriteRenderer.scaleFactor),
                        (int)(spriteRenderer.Rectangle.Height * spriteRenderer.scaleFactor)
                    );
                } else
                {
                    return new Rectangle
                    (
                        (int)(gameObject.transform.Position.X + spriteRenderer.Offset.X + (spriteRenderer.Rectangle.Width * spriteRenderer.scaleFactor * centerPercent / 2)),
                        (int)(gameObject.transform.Position.Y + spriteRenderer.Offset.Y),
                        (int)(spriteRenderer.Rectangle.Width * spriteRenderer.scaleFactor * centerPercent),
                        (int)(spriteRenderer.Rectangle.Height * spriteRenderer.scaleFactor)
                    );
                }

            }
        }

        public void LoadContent(ContentManager content)
        {
            texture = Globals.Graphics.CollisionTexture;
            if (gameObject.GetComponent("Base") is Base) { ownerType = "Base"; assocType = gameObject.GetComponent("Base"); }
            if (gameObject.GetComponent("EnemyBase") is EnemyBase) { ownerType = "EnemyBase"; assocType = gameObject.GetComponent("EnemyBase"); }
            if (gameObject.GetComponent("Pikeman") is Pikeman) { ownerType = "Pikeman"; assocType = gameObject.GetComponent("Pikeman"); doCollisionCheck = true; }
            //if (gameObject.GetComponent("EnemyPikeman") is EnemyPikeman) { ownerType = "EnemyPikeman"; assocType = gameObject.GetComponent("EnemyPikeman"); }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
#if DEBUG
            Rectangle topLine = new Rectangle(GetCollisionBox.X, GetCollisionBox.Y, GetCollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(GetCollisionBox.X, GetCollisionBox.Y + GetCollisionBox.Height, GetCollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(GetCollisionBox.X + GetCollisionBox.Width, GetCollisionBox.Y, 1, GetCollisionBox.Height);
            Rectangle leftLine = new Rectangle(GetCollisionBox.X, GetCollisionBox.Y, 1, GetCollisionBox.Height);
            spriteBatch.Draw(texture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
#endif
        }

        public void Update()
        {
            CheckCollision();
        }

        public void CheckCollision()
        {
            if (doCollisionCheck)
            {
                if (ownerType == "Pikeman")
                {
                    bool collides = false;
                    foreach (Collider col in GameWorld.Instance.Colliders)
                    {
                        if (col.ownerType != "Pikeman")
                        {
                            if (GetCollisionBox.Intersects(col.GetCollisionBox))
                            {
                                collides = true;
                                if (col.ownerType == "EnemyBase")
                                {
                                    (col.gameObject.GetComponent("EnemyBase") as EnemyBase).TakeDamage((assocType as Pikeman).damege);
                                }
                            }
                        }
                    }
                    if (collides)
                    {
                        (assocType as Pikeman).canwalk = false;
                    } 
                    else
                    {
                        (assocType as Pikeman).canwalk = true;
                    }
                }
            }
        }
    }
}