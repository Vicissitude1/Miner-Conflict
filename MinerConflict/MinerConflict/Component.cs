﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    class Component
    {
        private GameObject gameObject;

        /// <summary>
        /// Constructer for gameObjects
        /// </summary>
        public Component() { }
        /// <summary>
        /// Constructor for components for a gameobject
        /// </summary>
        /// <param name="gameObject">The associated object for the component</param>
        public Component(GameObject gameObject) { this.gameObject = gameObject; }
    }
}