using System.Drawing;

namespace AsteroidGame
{
    internal interface ICollision
    {
        Rectangle Rect { get; }

        bool CheckCollision(ICollision obj);
    }
}
