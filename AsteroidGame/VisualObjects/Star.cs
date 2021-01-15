using System.Drawing;

namespace AsteroidGame
{
    class Star : VisualObject
    {
        public Star(Point Position, Point Direction, int Size) : base(Position, Direction, new Size(Size, Size)) { }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.WhiteSmoke, _Position.X - _Size.Width / 2, _Position.Y - _Size.Height / 2, _Position.X + _Size.Width / 2, _Position.Y + _Size.Height / 2);
            g.DrawLine(Pens.WhiteSmoke, _Position.X + _Size.Width / 2, _Position.Y - _Size.Height / 2, _Position.X - _Size.Width / 2, _Position.Y + _Size.Height / 2);
            g.DrawLine(Pens.WhiteSmoke, _Position.X - _Size.Width, _Position.Y, _Position.X + _Size.Width, _Position.Y);
            g.DrawLine(Pens.WhiteSmoke, _Position.X, _Position.Y - _Size.Height, _Position.X, _Position.Y + _Size.Height);
        }

        public override void Update()
        {
            _Position.X = (_Position.X + _Direction.X + Game.Width) % Game.Width;
        }
    }
}
