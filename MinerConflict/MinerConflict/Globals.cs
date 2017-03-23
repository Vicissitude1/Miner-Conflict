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
            private static Texture2D pikemanUnitTexture;
            private static Texture2D minerWalkTexture;
            private static Texture2D pikemanWalkTexture;
            private static Texture2D collisionTexture;

            public static Texture2D MinerUnitTexture { get { return minerUnitTexture; } }
            public static Texture2D MineBuildingTexture { get { return mineBuildingTexture; } }
            public static Texture2D BaseBuildingTexture { get { return baseBuildingTexture; } }
            public static Texture2D PikemanUnitTexture { get { return pikemanUnitTexture; } }
            public static Texture2D MinerWalkTexture { get { return minerWalkTexture; } }
            public static Texture2D PikemanWalkTexture { get { return pikemanWalkTexture; } }
            public static Texture2D CollisionTexture { get { return collisionTexture; } }

            public static void LoadAllGraphics(ContentManager content)
            {
                minerUnitTexture = content.Load<Texture2D>("MinerUnit");
                mineBuildingTexture = content.Load<Texture2D>("MineBuilding");
                baseBuildingTexture = content.Load<Texture2D>("BaseBuilding");
                pikemanUnitTexture = content.Load<Texture2D>("pikemanUnit");
                minerWalkTexture = content.Load<Texture2D>("MinerWalk");
                pikemanWalkTexture = content.Load<Texture2D>("PikemanWalk");
                collisionTexture = content.Load<Texture2D>("CollisionTexture");
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
