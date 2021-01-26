using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public bool Enabled { get; set; } = true;

        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public abstract void Draw(Graphics g);

        public abstract void Update();

        public virtual void SetPosition(int X, int Y) => SetPosition(new Point(X, Y));

        public virtual void SetPosition(Point Point) => _Position = Point;
    }
}
