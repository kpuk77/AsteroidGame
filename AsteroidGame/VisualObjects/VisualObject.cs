using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    abstract class VisualObject
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

        public virtual void Update()
        {
            _Position.X = (_Position.X + _Direction.X + Game.Width) % Game.Width;
            _Position.Y = (_Position.Y + _Direction.Y + Game.Height) % Game.Height;
        }
    }
}
