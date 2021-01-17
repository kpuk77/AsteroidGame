using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class Asteroid : ImageObjects, ICollision
    {
        public int _Power { get; set; } = 3;

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public Asteroid(Point Position, Point Direction, Size Size) :
            base(Position, Direction, Size, Properties.Resources.Asteroid) { }

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
