﻿using System;
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
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X < 0)
                _Direction.X *= -1;
            if (_Position.Y < 0)
                _Direction.Y *= -1;
            if (_Position.X > 800 - _Size.Width)
                _Direction.X *= -1;
            if (_Position.Y > Game.Height - _Size.Width)
                _Direction.Y *= -1;
        }

    }
}