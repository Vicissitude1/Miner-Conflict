using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    class GameObject:Component
    {
        private List<Component> components;
        public float scaleFactor { get; set; }
        public Transform transform { get; private set; }

        public GameObject()
        {
            //Initialize
            components = new List<Component>();
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public Component GetComponent(string compName)
        {
            return components.Find(n => n.GetType().Name == compName);
        }
    }
}
