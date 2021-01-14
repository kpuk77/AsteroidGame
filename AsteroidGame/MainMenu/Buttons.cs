using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    static class Buttons
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static Button __BtnStart;
        private static Button __BtnRecords;
        private static Button __BtnExit;
        private static int __BtnWidth = 80;
        private static int __BtnHeight = 30;

        public static void InitializeControls(Form GameForm)
        {
            __BtnStart = new Button();
            __BtnStart.Text = "Новая игра";
            __BtnStart.Size = new Size(__BtnWidth, __BtnHeight);
            __BtnStart.Location = new Point(GameForm.ClientSize.Width / 2 - __BtnStart.Size.Width / 2, GameForm.ClientSize.Height / 2 - __BtnStart.Size.Height);
            GameForm.Controls.Add(__BtnStart);

            __BtnRecords = new Button();
            __BtnRecords.Text = "Рекорды";
            __BtnRecords.Size = __BtnStart.Size;
            __BtnRecords.Location = new Point(__BtnStart.Location.X, __BtnStart.Location.Y + __BtnRecords.Size.Height);
            GameForm.Controls.Add(__BtnRecords);

            __BtnExit = new Button();
            __BtnExit.Text = "Выход";
            __BtnExit.Size = __BtnStart.Size;
            __BtnExit.Location = new Point(__BtnStart.Location.X, __BtnRecords.Location.Y + __BtnExit.Size.Height);
            GameForm.Controls.Add(__BtnExit);

            __BtnStart.Click += __BtnStart_Click;
            __BtnExit.Click += __BtnExit_Click;
            __BtnRecords.Click += __BtnRecords_Click;
        }

        private static void __BtnRecords_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Иванов\n2. Петров\n3. Сидоров", "Рекорды", MessageBoxButtons.OK);
        }

        private static void __BtnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Как реализовать запуск ?", "Эмм?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private static void __BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static private void DrawBtn(Button btn)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;
            int width = btn.Size.Width;
            int height = btn.Size.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = btn.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(x, y, width, height));
        }

        static public void Draw()
        {
            DrawBtn(__BtnStart);
            DrawBtn(__BtnRecords);
            DrawBtn(__BtnExit);
        }
    }
}
