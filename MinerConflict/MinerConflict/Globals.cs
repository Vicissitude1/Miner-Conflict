using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    enum DIRECTION { Left, Right }

    public static class Globals
    {
        public static class LayerD
        {

        }

        public static class Graphics
        {
            private static Texture2D minerUnitTexture;
            private static Texture2D mineBuildingTexture;
            private static Texture2D baseBuildingTexture;

            public static Texture2D MinerUnitTexture { get { return minerUnitTexture; } }
            public static Texture2D MineBuildingTexture { get { return mineBuildingTexture; } }
            public static Texture2D BaseBuildingTexture { get { return baseBuildingTexture; } }

            public static void LoadAllGraphics(ContentManager content)
            {
                minerUnitTexture = content.Load<Texture2D>("MinerUnit");
                mineBuildingTexture = content.Load<Texture2D>("MineBuilding");
                baseBuildingTexture = content.Load<Texture2D>("BaseBuilding");
            }

            /*
            Sprite Miner Graphics Infor
                Mining:
                10 frames
                48x65
            
                Walk:
                skip 4, 6 frames
                48x51 (Y might be wrong...)
            */
        }
    }
}
