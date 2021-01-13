using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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

        public void Draw(Graphics g)
        {
            g.DrawEllipse(
                Pens.White,
                _Position.X, _Position.Y,
                _Size.Width, _Size.Height);
        }

        public void Update()
        {
            _Position.X = (_Position.X + _Direction.X + Game.Width) % Game.Width;
            _Position.Y = (_Position.Y + _Direction.Y + Game.Height) % Game.Height;
        }

    }
}
