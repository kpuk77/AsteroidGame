using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class Bullet : VisualObject, ICollision
    {
        public Bullet(Point Position, Point Direction, int Size) :
            base(Position, Direction, new Size(Size, Size)) { }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

        public override void Draw(Graphics g) => g.FillEllipse(
            brush: Brushes.Red,
            x: _Position.X,
            y: _Position.Y,
            width: _Size.Width,
            height: _Size.Height);

        public override void Update() => _Position.X += _Direction.X;
    }
}
