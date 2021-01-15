using System.Drawing;

namespace AsteroidGame
{
    class RoundStar : VisualObject
    {
        public RoundStar(Point Position, Point Direction, int Size) : base(Position, Direction, new Size(Size, Size)) { }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.LightGoldenrodYellow, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Position.X = (_Position.X + _Direction.X + Game.Width) % Game.Width;
        }
    }
}
