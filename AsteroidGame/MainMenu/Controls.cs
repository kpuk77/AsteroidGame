using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame.MainMenu
{
    internal static class Controls
    {
        private static Button __BtnStart;
        private static Button __BtnRecords;
        private static Button __BtnExit;
        private static int __BtnWidth = 80;
        private static int __BtnHeight = 30;

        private static bool _Visible
        {
            set
            {
                __BtnStart.Enabled = value;
                __BtnRecords.Enabled = value;
                __BtnExit.Enabled = value;
                __BtnStart.Visible = value;
                __BtnRecords.Visible = value;
                __BtnExit.Visible = value;
            }
        }

        public static void InitializeControls(Form GameForm)
        {
            __BtnStart = new Button();
            __BtnStart.Text = "Новая игра";
            __BtnStart.Size = new Size(__BtnWidth, __BtnHeight);
            __BtnStart.Location = new Point(
                GameForm.ClientSize.Width / 2 - __BtnStart.Size.Width / 2,
                GameForm.ClientSize.Height / 2 - __BtnStart.Size.Height);
            GameForm.Controls.Add(__BtnStart);

            __BtnRecords = new Button();
            __BtnRecords.Text = "Рекорды";
            __BtnRecords.Size = __BtnStart.Size;
            __BtnRecords.Location = new Point(
                __BtnStart.Location.X, 
                __BtnStart.Location.Y + __BtnRecords.Size.Height);
            GameForm.Controls.Add(__BtnRecords);

            __BtnExit = new Button();
            __BtnExit.Text = "Выход";
            __BtnExit.Size = __BtnStart.Size;
            __BtnExit.Location = new Point(
                __BtnStart.Location.X,
                __BtnRecords.Location.Y + __BtnExit.Size.Height);
            GameForm.Controls.Add(__BtnExit);

            __BtnStart.Click += __BtnStart_Click;
            __BtnExit.Click += __BtnExit_Click;
            __BtnRecords.Click += __BtnRecords_Click;
        }

        private static void __BtnRecords_Click(object sender, EventArgs e) 
            => MessageBox.Show("1. Иванов\n2. Петров\n3. Сидоров", "Рекорды", MessageBoxButtons.OK);

        private static void __BtnStart_Click(object sender, EventArgs e)
        {
            Menu._Enable = false;
            Game.Enable = true;
            _Visible = false;
            InfoText._Visible = false;
        }

        private static void __BtnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}