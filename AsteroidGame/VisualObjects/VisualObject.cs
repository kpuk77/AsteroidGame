using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public abstract void Draw(Graphics g);

        public abstract void Update();

        public void SetPosition(int X, int Y)
        {
            _Position.X = X;
            _Position.Y = Y;
        }
    }
}
