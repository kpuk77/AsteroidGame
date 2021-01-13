using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;

        private static Random rand;

        public static int Width { get; set; } = 0;
        public static int Height { get; set; } = 0;
        public static void Initialize(Form GameForm)
        {
            Width = GameForm.ClientSize.Width;
            Height = GameForm.ClientSize.Height;

            rand = new Random();

            __Context = BufferedGraphicsManager.Current;
            Graphics g = GameForm.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer() { Interval = 100 };

            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            
            const int VISUAL_OBJECTS_COUNT = 30;

            __GameObjects = new VisualObject[VISUAL_OBJECTS_COUNT];

            for (int i = 0; i < __GameObjects.Length; i++)
            {
                int size = rand.Next(10, 20);
                __GameObjects[i] = new VisualObject(
                    new Point(rand.Next(0, Width), rand.Next(0, Height)),
                    new Point(rand.Next(-15, 15), rand.Next(-15, 15)),
                    new Size(size, size));
            }
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var obj in __GameObjects)
            {
                obj.Draw(g);
            }

            __Buffer.Render();
        }

        private static void Update()
        {
            foreach (var obj in __GameObjects)
            {
                obj.Update();
            }
        }

    }
}
