﻿using System;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.MainMenu.MenuObjects;

namespace AsteroidGame.MainMenu
{
    internal static class Menu
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static Random __Rand;
        private static MenuVisualObject[] __VisualObjects;
        private static Timer __Timer;

        public static bool Enable
        {
            get => __Timer.Enabled;
            set => __Timer.Enabled = value;
        }

        private const int _VISUAL_OBJECTS_COUNT = 5000;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Initialize(Form GameForm)
        {
            __Rand = new Random();

            Width = GameForm.ClientSize.Width;
            Height = GameForm.ClientSize.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = GameForm.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            __Timer = new Timer() { Interval = 1 };
            __Timer.Tick += OnTimerTick;
            __Timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            __VisualObjects = new MenuVisualObject[_VISUAL_OBJECTS_COUNT];
            for (int i = 0; i < __VisualObjects.Length; i++)
            {
                __VisualObjects[i] = new ScreenStar(
                    __Rand.Next(-Width, Width),
                    __Rand.Next(-Height, Height),
                    __Rand.Next(1, Width));
            }
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var obj in __VisualObjects)
                obj.Draw(g);
            __Buffer.Render();
        }

        private static void Update()
        {
            foreach (var obj in __VisualObjects)
                obj.Update();
        }
    }
}
