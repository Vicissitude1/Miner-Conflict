﻿using Microsoft.Xna.Framework;
using MinerConflict.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MinerConflict
{
    //nej
    class GameObject:Component, IAnimateable, IUpdate
    {
        private List<Component> components;
        public Transform transform { get; private set; }

        private Thread updateThread;
        private bool alreadyChecked;
        private delegate void updateDelegate();
        private List<updateDelegate> delegates;
        private event updateDelegate triggerUpdate;

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
            //FISK
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
            while (true)
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
}
