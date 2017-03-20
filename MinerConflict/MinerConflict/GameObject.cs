using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    //nej
    class GameObject:Component, IAnimateable
    {
        private List<Component> components;
        public Transform transform { get; private set; }

        public GameObject(Vector2 position)
        {
            //Initialize
            components = new List<Component>();
            transform = new Transform(this, position);
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public Component GetComponent(string compName)
        {
            return components.Find(n => n.GetType().Name == compName);
        }

        public void OnAnimationDone(string animationName)
        {
            //FISK
        }
    }
}
