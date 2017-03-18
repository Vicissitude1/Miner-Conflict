using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    public static class Globals
    {
        public static class LayerD
        {

        }

        public static class Graphics
        {
            private static Texture2D minerUnitTexture;
            private static Texture2D mineBuildingTexture;

            public static Texture2D MinerUnitTexture { get { return minerUnitTexture; } }
            public static Texture2D MineBuildingTexture { get { return mineBuildingTexture; } }

            public static void LoadAllGraphics(ContentManager content)
            {
                minerUnitTexture = content.Load<Texture2D>("Replace");
                mineBuildingTexture = content.Load<Texture2D>("Replace");
            }
        }
    }
}
