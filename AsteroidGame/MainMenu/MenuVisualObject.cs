using System;
using System.Drawing;

namespace AsteroidGame.MainMenu
{
    internal class MenuVisualObject
    {
        protected float _X;
        protected float _Y;
        protected float _Z;

        private int _StarSpeed = 2;
        private readonly Random _Rand;

        public MenuVisualObject(float X, float Y, float Z)
        {
            _X = X;
            _Y = Y;
            _Z = Z;
            _Rand = new Random();
        }

        public virtual void Draw(Graphics g)
        {
            float size = Map(_Z, 0, Menu._Width, 5, 0);
            float x = Map(_X / _Z, 0, 1, 0, Menu._Width) + Menu._Width / 2;
            float y = Map(_Y / _Z, 0, 1, 0, Menu._Height) + Menu._Height / 2;

            g.FillEllipse(Brushes.LightGoldenrodYellow, x, y, size, size);
        }

        private float Map(float n, float start1, float stop1, float start2, float stop2) =>
            ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;

        public virtual void Update()
        {
            _Z -= _StarSpeed;

            if (_Z < 1)
            {
                _X = _Rand.Next(-Menu._Width, Menu._Width);
                _Y = _Rand.Next(-Menu._Height, Menu._Height);
                _Z = _Rand.Next(1, Menu._Width);
            }
        }
    }
}
