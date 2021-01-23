using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class RoundStar : VisualObject
    {
        public RoundStar(Point Position, Point Direction, int Size) :
            base(Position, Direction, new Size(Size, Size)) { }

        public override void Draw(Graphics g)
        {
            if (!_Enabled) return;

            g.FillEllipse(
                brush: Brushes.LightGoldenrodYellow,
                x: _Position.X,
                y: _Position.Y,
                width: _Size.Width,
                height: _Size.Height);
        }

        public override void Update()
        {
            if (!_Enabled) return;

            _Position.X = (_Position.X + _Direction.X + Game._Width) % Game._Width;
        }
    }
}
