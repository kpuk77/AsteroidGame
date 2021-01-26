using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using AsteroidGame.Service;
using AsteroidGame.VisualObjects;


namespace AsteroidGame
{
    internal static class Game
    {
        private static Action<string> __Log;
        private static Logger __Logger;
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __VisualGameObjects;
        private static List<Bullet> __Bullets;
        private static Ship __Ship;
        private static FirstAid __FirstAid;

        private static Timer __Timer;
        private static Timer __FirstAidTimer;
        private static Random __Rand;

        public static int Score { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static bool Enable
        {
            get => __Timer.Enabled;
            set
            {
                __FirstAidTimer.Enabled = value;
                __Timer.Enabled = value;
            }
        }

        public static void Initialize(Form GameForm)
        {
            Width = GameForm.ClientSize.Width;
            Height = GameForm.ClientSize.Height;

            __Rand = new Random();

            __Logger = new Logger();

            //__Log = __Logger.LogInConsole;
            __Log += __Logger.LogInFile;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = GameForm.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            __Timer = new Timer() { Interval = 20 };
            __Timer.Tick += OnTimerTick;

            __FirstAidTimer = new Timer() { Interval = 5000 };
            __FirstAidTimer.Tick += FirstAidTimer_Tick;

            GameForm.KeyDown += OnGameForm_KeyDown;
        }

        private static void OnGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    __Ship.MoveDown();
                    __Log?.Invoke($"MoveDown.");
                    break;
                case Keys.Up:
                    __Ship.MoveUp();
                    __Log?.Invoke($"MoveUp.");
                    break;
                case Keys.ControlKey:
                    var emptyBullet = __Bullets.FirstOrDefault(b => !b.Enabled);
                    if (emptyBullet != null)
                    {
                        emptyBullet.SetPosition(__Ship.Rect.Width, __Ship.Rect.Y + __Ship.Rect.Height / 2);
                        emptyBullet.Enabled = true;
                    }
                    else
                        __Bullets.Add(new Bullet(
                        new Point(__Ship.Rect.Width, __Ship.Rect.Y + __Ship.Rect.Height / 2),
                        new Point(15, 0),
                        new Size(5, 5)));
                    __Log?.Invoke($"Shoot on coords Y: {__Ship.Rect.Y}.");
                    break;
            }
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
            const int ASTEROIDS_COUNT = 8;

            var gameObjects = new List<VisualObject>();

            __FirstAid = new FirstAid(__Rand.Next(0, Height));
            __FirstAid.Enabled = false;

            __Bullets = new List<Bullet>();
            __Ship = new Ship(
                new Point(5, Height / 2),
                new Point(10, 10),
                new Size(150, 42));

            __Ship.ShipLog(__Log);
            __Ship.Destroyed += OnDestroyed;

            for (int i = 0; i < STARS_COUNT; i++)
            {
                int size = __Rand.Next(5, 7);
                gameObjects.Add(new Star(
                    new Point(__Rand.Next(0, Width), __Rand.Next(0, Height)),
                    new Point(__Rand.Next(-5, -1), 0),
                    size));
            }

            for (int i = 0; i < ROUND_STARS_COUNT; i++)
            {
                int speed = 5;
                int size = __Rand.Next(3, 5);
                gameObjects.Add(new RoundStar(
                    new Point(__Rand.Next(0, Width), __Rand.Next(0, Height)),
                    new Point(__Rand.Next(-speed, speed), 0),
                    size));
            }

            for (int i = 0; i < ASTEROIDS_COUNT; i++)
            {
                int speed = 5;
                gameObjects.Add(new Asteroid(
                    Position: new Point(__Rand.Next(200, Width), __Rand.Next(0, Height)),
                    Direction: new Point(__Rand.Next(-speed, speed), __Rand.Next(-speed, speed)),
                    Size: new Size(__Rand.Next(40, 60), __Rand.Next(40, 60))));
            }

            __VisualGameObjects = gameObjects.ToArray();
        }

        private static void OnDestroyed(object sender, EventArgs e)
        {
            Enable = false;
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);
            g.DrawString("GameOver", new Font(FontFamily.GenericMonospace, 20), Brushes.Red, 200, 200);
            g.DrawString($"Score: {Score}", new Font(FontFamily.GenericMonospace, 20), Brushes.Yellow, 200, 250);

            __Buffer.Render();
        }

        private static void FirstAidTimer_Tick(object sender, EventArgs e)
        {
            if (!__FirstAid.Enabled) __FirstAid.Enabled = true;

            __FirstAid.SetPosition(50, __Rand.Next(0, Height - __FirstAid.Rect.Size.Height));
            __Log?.Invoke($"FirstAid spawn on coords Y: {__FirstAid.Rect.Y}");
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var obj in __VisualGameObjects.Where(o => o.Enabled))
                obj.Draw(g);

            __Bullets.ForEach(b => b.Draw(g));

            __Ship.Draw(g);
            __FirstAid.Draw(g);

            g.DrawString($"HP: {__Ship.Energy}", new Font(FontFamily.GenericMonospace, 10), Brushes.Green, 0, 0);
            g.DrawString($"Score: {Score}", new Font(FontFamily.GenericMonospace, 10), Brushes.Yellow, 0, 13);


            if (!Enable) return;
            __Buffer.Render();
        }

        private static void Update()
        {
            foreach (var visualObject in __VisualGameObjects.Where(o => o.Enabled))
                visualObject.Update();

            __Bullets.ForEach(b => b.Update());

            foreach (var visualObject in __VisualGameObjects.Where(o => o.Enabled))
            {
                if (visualObject is not ICollision obj) continue;

                foreach (var bullet in __Bullets.Where(b => b.Enabled))
                    if (bullet.CheckCollision(obj))
                    {
                        bullet.Enabled = false;
                        visualObject.Enabled = false;
                        Score += 10;
                        __Log?.Invoke($"Asteroid and bullet collision X: {bullet.Rect.X} Y:{bullet.Rect.Y}");
                    }

                if (__Ship.CheckCollision(obj))
                {
                    visualObject.Enabled = false;
                    __Log?.Invoke($"Ship collision with {obj.GetType()} on X: {__Ship.Rect.X} Y: {__Ship.Rect.Y}. Ship energy: {__Ship.Energy}");
                }
            }

            if (__Ship.CheckCollision(__FirstAid)) __FirstAid.Enabled = false;

            var visualObjects = __VisualGameObjects.Where(o => o is Asteroid).
                OrderByDescending(o => o.Enabled).ToArray();

            if (visualObjects[0].Enabled == false) AsteroidsReborn(visualObjects);
        }

        private static void AsteroidsReborn(VisualObject[] a)
        {
            var ast = a.ToList();
            foreach (var asteroid in ast)
            {
                asteroid.Enabled = true;

                asteroid.SetPosition(__Rand.Next(200, Width), __Rand.Next(0, Height));

                __Log?.Invoke($"Asteroids respawn.");
            }
        }
    }
}
