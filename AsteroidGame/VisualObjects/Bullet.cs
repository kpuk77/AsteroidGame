using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class Bullet : VisualObject
    {
        private int _Speed = 3;
        public Bullet(Point Position, Point Direction, int Size) : base(Position, Direction, new Size(Size, Size)) { }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Position.X += _Speed;
        }
    }
}
