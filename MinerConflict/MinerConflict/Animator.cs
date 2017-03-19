using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace MinerConflict
{
    class Animator
    {
        private SpriteRenderer spriteRendere;
        private int currentIndex;
        private float timeElapsed;
        private float fps;
        private Rectangle[] reactangles;
        private string animationName;

        public Dictionary<string, Animation> Animations { get; set; }

        public Animator(GameObject gameObject) : base(gameObject)
        {
            fps = 5;
            this.spriteRendere = (SpriteRenderer)gameObject.GetComponent("SpriteRendere");
            Animations = new Dictionary<string, Animation>();
        }
    }
}
