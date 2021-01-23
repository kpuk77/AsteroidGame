using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using AsteroidGame.VisualObjects;


namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static VisualObject[] __GameObjects;
        //private static Asteroid[] __Asteroids;
        //private static Bullet[] __Bullets;
        private static Timer __Timer;
        private static Random __Rand;

        public static bool Enable
        {
            get => __Timer.Enabled;
            set => __Timer.Enabled = value;
        }

        public static int Width { get; set; } = 0;
        public static int Height { get; set; } = 0;
        public static void Initialize(Form GameForm)
        {
            Width = GameForm.ClientSize.Width;
            Height = GameForm.ClientSize.Height;

            __Rand = new Random();

            __Context = BufferedGraphicsManager.Current;
            Graphics g = GameForm.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            __Timer = new Timer() { Interval = 20 };
            __Timer.Tick += OnTimerTick;
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            const int STARS_COUNT = 15;
            const int ROUND_STARS_COUNT = 15;
            const int BULLETS_COUNT = 10;
            const int ASTEROIDS_COUNT = 8;

            var gameObjects = new List<VisualObject>();
            //__Asteroids = new Asteroid[ASTEROIDS_COUNT];
            //__Bullets = new Bullet[BULLETS_COUNT];

            for (int i = 0; i < STARS_COUNT; i++)
            {
                int size = __Rand.Next(5, 7);
                gameObjects.Add(new Star(
                    Position: new Point(__Rand.Next(0, Width), __Rand.Next(0, Height)),
                    Direction: new Point(__Rand.Next(-5, -1), 0),
                    Size: size));
            }

            for (int i = 0; i < BULLETS_COUNT; i++)
            {
                int speed = 5;
                gameObjects.Add(new Bullet(
                    Position: new Point(0, __Rand.Next(0, Height)),
                    Direction: new Point(speed, 0),
                    Size: new Size(10, 5)));
            }

            for (int i = 0; i < ROUND_STARS_COUNT; i++)
            {
                int speed = 5;
                int size = __Rand.Next(3, 5);
                gameObjects.Add(new RoundStar(
                    Position: new Point(__Rand.Next(0, Width), __Rand.Next(0, Height)),
                    Direction: new Point(__Rand.Next(-speed, speed), 0),
                    Size: size));
            }

            for (int i = 0; i < ASTEROIDS_COUNT; i++)
            {
                int speed = 5;
                int size = __Rand.Next(40, 60);
                gameObjects.Add(new Asteroid(
                    Position: new Point(__Rand.Next(0, Width), __Rand.Next(0, Height)),
                    Direction: new Point(__Rand.Next(-speed, speed), __Rand.Next(-5, 5)),
                    Size: new Size(size, size)));
            }

            __GameObjects = gameObjects.ToArray();
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var obj in __GameObjects.Where(o => Enable))
                obj.Draw(g);

            __Buffer.Render();
        }

        private static void Update()
        {
            foreach (var obj in __GameObjects.Where(o => Enable))
                obj.Update();

            //foreach (var a in __Asteroids)
            //{
            //    a.Update();
            //    foreach (var b in __Bullets)
            //    {
            //        if (a.CheckCollision(b))
            //        {
            //            b.SetPosition(0, __Rand.Next(0, Height));
            //            a.SetPosition(Width, __Rand.Next(0, Height));
            //        }
            //        b.Update();
            //    }
            //}
        }
    }
}
