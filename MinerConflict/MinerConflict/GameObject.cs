using Microsoft.Xna.Framework;
using MinerConflict.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace MinerConflict
{
    //You are raider! Legendary!
    class GameObject:Component, IAnimateable, IUpdate, ILoadeble
    {
        private List<Component> components;
        public Transform transform { get; private set; }

        private Thread updateThread;
        private bool alreadyChecked;
        private delegate void updateDelegate();
        private List<updateDelegate> delegates;
        private event updateDelegate triggerUpdate;
        private double cycles;

        public GameObject(Vector2 position)
        {
            //Initialize
            components = new List<Component>();
            delegates = new List<updateDelegate>();
            alreadyChecked = false;
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
        //monkey.
        }

        public void Update()
        {
            if (updateThread == null && alreadyChecked == false)
            {
                foreach (Component obj in components)
                {
                    if (obj is IUpdate)
                    {
                        delegates.Add((obj as IUpdate).Update);
                    }
                }
                alreadyChecked = true;
                if (delegates.Count > 0)
                {
                    foreach (updateDelegate del in delegates)
                    {
                        triggerUpdate += del;
                    }
                    updateThread = new Thread(ThreadUpdate);
                    updateThread.IsBackground = true;
                    updateThread.Start();
                }
            }
        }

        

        private void ThreadUpdate()
        {
            cycles = GameWorld.Instance.cycles;
            while (true)
            {
                if (cycles < GameWorld.Instance.cycles)
                    {
                    try
                    {
                        triggerUpdate();
                    } catch
                    {
                        break;
                    }
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Component com in components)
            {
                if(com is ILoadeble)
                {
                    (com as ILoadeble).LoadContent(content); 
                }
            }
        }
    }
}
