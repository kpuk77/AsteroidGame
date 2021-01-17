using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class Star : VisualObject
    {
        public Star(Point Position, Point Direction, int Size) :
            base(Position, Direction, new Size(Size, Size)) { }

        public override void Draw(Graphics g)
        {
            g.DrawLine(
                pen: Pens.WhiteSmoke,
                x1: _Position.X - _Size.Width / 2,
                y1: _Position.Y - _Size.Height / 2,
                x2: _Position.X + _Size.Width / 2,
                y2:_Position.Y + _Size.Height / 2);
            g.DrawLine(
                Pens.WhiteSmoke, 
                x1: _Position.X + _Size.Width / 2,
                y1: _Position.Y - _Size.Height / 2,
                x2: _Position.X - _Size.Width / 2,
                y2:_Position.Y + _Size.Height / 2);
            g.DrawLine(
                Pens.WhiteSmoke, 
                x1: _Position.X - _Size.Width, 
                y1: _Position.Y, 
                x2: _Position.X + _Size.Width,
                y2:_Position.Y);
            g.DrawLine(
                Pens.WhiteSmoke, 
                x1: _Position.X,
                y1: _Position.Y - _Size.Height, 
                x2: _Position.X,
                y2:_Position.Y + _Size.Height);
        }

        public override void Update()
        {
            _Position.X = (_Position.X + _Direction.X + Game.Width) % Game.Width;
        }
    }
}
