using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class FirstAid : ImageObjects, ICollision
    {
        private int _Power = 3;
        public int Power => _Power;

        public FirstAid(int Y)
            : base(new Point(50, Y), Point.Empty, new Size(57, 60), Properties.Resources.firstAid)
        {
        }

        public override void Update() { }

        public Rectangle Rect => new Rectangle(_Position, _Size);
        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
