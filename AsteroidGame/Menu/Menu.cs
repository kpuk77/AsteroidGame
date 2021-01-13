using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame.Menu
{
    static class Menu
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static Random rand;
        private static MenuVisualObject[] _VisualObjects;

        const int VISUAL_OBJECTS_COUNT = 5000;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public  static void Initialize(Form GameForm)
        {
            InitializeControls(GameForm);
            rand = new Random();

            Width = GameForm.ClientSize.Width;
            Height = GameForm.ClientSize.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = GameForm.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer() { Interval = 50 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void InitializeControls(Form GameForm)
        {
            Button btnStart = new Button();
            btnStart.Text = "Новая игра";
            btnStart.Size = new Size(60, 20);
            btnStart.Location = new Point(Width / 2 - btnStart.Size.Width / 2, Height / 2 - btnStart.Size.Height);
            GameForm.Controls.Add(btnStart);
            btnStart.BringToFront();

            Button btnRecords = new Button();
            btnRecords.Text = "Рекорды";
            btnRecords.Size = btnStart.Size;
            btnRecords.Location = new Point(btnStart.Location.X, btnStart.Location.Y - btnRecords.Size.Height + 5);
            GameForm.Controls.Add(btnRecords);
            btnRecords.BringToFront();

            Button btnExit = new Button();
            btnExit.Text = "Выход";
            btnExit.Size = btnStart.Size;
            btnExit.Location = new Point(btnStart.Location.X, btnRecords.Location.Y - btnExit.Size.Height + 5);
            GameForm.Controls.Add(btnExit);
            btnExit.BringToFront();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            _VisualObjects = new MenuVisualObject[VISUAL_OBJECTS_COUNT];
            for (int i = 0; i < _VisualObjects.Length; i++)
            {
                _VisualObjects[i] = new ScreenStar(
                    rand.Next(-Width, Width),
                    rand.Next(-Height,Height),
                    rand.Next(1, Width));
            }
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var obj in _VisualObjects)
            {
                obj.Draw(g);
            }

            __Buffer.Render();
        }

        private static void Update()
        {
            foreach (var obj in _VisualObjects)
            {
                obj.Update();
            }
        }

       
    }
}
