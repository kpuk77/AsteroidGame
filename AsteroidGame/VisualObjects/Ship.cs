﻿using System;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class Ship : ImageObjects, ICollision
    {
        public event EventHandler Destroyed;

        private int _Energy = 12;
        private int _MaxEnergy = 12;
        public int Energy => _Energy;
        public Ship(Point Position, Point Direction, Size Size)
            : base(Position, Direction, Size, Properties.Resources.ship)
        {
        }

        public override void Update() { }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj)
        {
            var isCollision = Rect.IntersectsWith(obj.Rect);
            if (isCollision && obj is Asteroid asteroid)
            {
                ChangeEnergy(-asteroid.Power);
                if (Energy <= 0)
                {
                    Destroyed?.Invoke(this, EventArgs.Empty);
                    _ShipActionLog?.Invoke("Ship destroyed.");
                }
            }

            if (isCollision && obj is FirstAid firstAid && firstAid.Enabled)
            {
                if (Energy < _MaxEnergy)
                    ChangeEnergy(firstAid.Power);

                _ShipActionLog?.Invoke($"Ship gain energy:{firstAid.Power}");
            }

            return isCollision;
        }

        private void ChangeEnergy(int pow)
        {
            _Energy += pow;

            if (_Energy < 0)
                Game.Enable = false;
        }

        private Action<string> _ShipActionLog;

        public void ShipLog(Action<string> act)
        {
            _ShipActionLog = act;
        }

        public void MoveUp() => _Position.Y = (_Position.Y - _Direction.Y + Game.Height) % Game.Height;

        public void MoveDown() => _Position.Y = (_Position.Y + _Direction.Y + Game.Height) % Game.Height;
    }
}
