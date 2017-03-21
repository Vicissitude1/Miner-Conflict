using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MinerConflict.Interfaces;

namespace MinerConflict
{
    class Animator : Component, IUpdate
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

            currentIndex += (int)(timeElapsed * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                gameObject.OnAnimationDone(animationName);
                timeElapsed = 0;
                currentIndex = 0;
            }
            spriteRenderer.Rectangle = rectangles[currentIndex];
        }

        public void CreateAnimation(string name, Animation animation)
        {
            Animations.Add(name, animation);
        }

        public void PlayAnimation(string animationName)
        {
            if (this.animationName != animationName)
            {
                //set rectangle
                this.rectangles = Animations[animationName].Rectangles;

                //reset rectangle
                this.spriteRenderer.Rectangle = rectangles[0];

                //set offset
                this.spriteRenderer.Offset = Animations[animationName].Offset;

                //set animation name
                this.animationName = animationName;

                //set fps
                this.fps = Animations[animationName].Fps;

                //reset the animation
                timeElapsed = 0;

                currentIndex = 0;
            }
        }
    }
}
