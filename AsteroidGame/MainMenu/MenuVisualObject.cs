using System;
using System.Drawing;

namespace AsteroidGame
{
    class MenuVisualObject
    {
        protected float _X;
        protected float _Y;
        protected float _Z;

        private int _StarSpeed = 10;
        private Random _rand;

        public MenuVisualObject(float X, float Y, float Z)
        {
            _X = X;
            _Y = Y;
            _Z = Z;
            _rand = new Random();
        }

        public virtual void Draw(Graphics g)
        {
            float size = Map(_Z, 0, Menu.Width, 5, 0);
            float x = Map(_X / _Z, 0, 1, 0, Menu.Width) + Menu.Width / 2;
            float y = Map(_Y / _Z, 0, 1, 0, Menu.Height) + Menu.Height / 2;

            g.FillEllipse(Brushes.LightGoldenrodYellow, x, y, size, size);
        }

        private float Map(float n, float start1, float stop1, float start2, float stop2) => ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;

        public virtual void Update()
        {
            _Z -= _StarSpeed;

            if (_Z < 1)
            {
                _X = _rand.Next(-Menu.Width, Menu.Width);
                _Y = _rand.Next(-Menu.Height, Menu.Height);
                _Z = _rand.Next(1, Menu.Width);
            }
        }
    }
}
