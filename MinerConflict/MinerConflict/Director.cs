using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MinerConflict.Builders;

namespace MinerConflict
{
    class Director
    {
        private IBuilder builder;

        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public GameObject Construct(Vector2 position)
        {
            builder.Buildpart(position);
            return builder.GetResult();
        }
    }
}
