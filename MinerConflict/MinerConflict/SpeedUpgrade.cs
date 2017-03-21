using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerConflict
{
    abstract class SpeedUpgrade:Component
    {
        public static float speed;

        public SpeedUpgrade(GameObject gameObject):base(gameObject)
        {
            speed = 4f;
        }
    }
}
