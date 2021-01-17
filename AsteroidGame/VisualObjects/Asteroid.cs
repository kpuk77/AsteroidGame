using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class Asteroid : ImageObjects
    {
        public int _Power { get; set; } = 3;

        public Asteroid(Point Position, Point Direction, Size Size) :
            base(Position, Direction, Size, Properties.Resources.Asteroid) { }

    }
}
