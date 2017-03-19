using Microsoft.Xna.Framework;

namespace MinerConflict.Builders
{
    interface IBuilder
    {
        GameObject GetResult();

        void Buildpart(Vector2 position);
    }
}