using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace MinerConflict
{
    class Animator : Component
    {
        private SpriteRenderer spriteRenderer;
        private int currentIndex;
        private float timeElapsed;
        private float fps;
        private Rectangle[] rectangles;
        private string animationName;

        public Dictionary<string, Animation> Animations { get; set; }

        public Animator(GameObject gameObject) : base(gameObject)
        {
            fps = 5;
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
            Animations = new Dictionary<string, Animation>();
        }

        public void Update()
        {

            timeElapsed += GameWorld.Instance.deltaTime;

            currentIndex = (int)(timeElapsed * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                GameObject.OnAnimationDone(animationName);
                timeElapsed = 0;
                currentIndex = 0;
            }
            spriteRenderer.Rectangle = rectangles[currentIndex];
        }
    }
}
