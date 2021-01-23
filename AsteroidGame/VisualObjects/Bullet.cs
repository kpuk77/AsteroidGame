using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class Bullet : VisualObject, ICollision
    {
        public Bullet(Point Position, Point Direction, Size Size) :
            base(Position, Direction, Size) { }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

        public override void Draw(Graphics g)
        {
            if (!_Enabled) return;

            var rect = Rect;
            g.FillEllipse(Brushes.Red, rect);
            g.DrawEllipse(Pens.White, rect);
        }

        public override void Update()
        {
            if (!_Enabled) return;
            
            _Position.X += _Direction.X;
        }

        public bool IsOnDisplay() => _Position.X <= Game.Width;
    }
}
