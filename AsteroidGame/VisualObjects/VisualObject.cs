using System.Drawing;

namespace AsteroidGame
{
    class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawEllipse(
                pen: Pens.White,
                x: _Position.X,
                y: _Position.Y,
                width: _Size.Width,
                height: _Size.Height);
        }

        public virtual void Update()
        {
            _Position.X = (_Position.X + _Direction.X + Game.Width) % Game.Width;
            _Position.Y = (_Position.Y + _Direction.Y + Game.Height) % Game.Height;
        }
    }
}
