using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class ImageObjects : VisualObject
    {
        private readonly Image _Image;
        public ImageObjects(Point Position, Point Direction, Size Size, Image Image) 
            : base(Position, Direction, Size)
        {
            _Image = Image;
        }

        public override void Draw(Graphics g)
        {
            if (!Enabled) return;

            g.DrawImage(_Image, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            if (!Enabled) return;

            _Position.X = (_Position.X + _Direction.X + Game.Width) % Game.Width;
            _Position.Y = (_Position.Y + _Direction.Y + Game.Height) % Game.Height;
        }
    }
}