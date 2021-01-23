using System;
using System.Windows.Forms;
using AsteroidGame.MainMenu;

namespace AsteroidGame
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form gameForm = new Form();

            gameForm.Width = 1000;
            gameForm.Height = 600;
            gameForm.Text = @"Asteroid game";
            gameForm.MinimizeBox = false;
            gameForm.MaximizeBox = false;
            gameForm.FormBorderStyle = FormBorderStyle.Fixed3D;

            if (gameForm.Width > 1000 || gameForm.Height > 1000 || gameForm.Width < 0 || gameForm.Height < 0)
                throw new ArgumentOutOfRangeException();

            gameForm.Show();

            Menu.Initialize(gameForm);
            Menu.Load();
            Menu.Draw();
            InfoText.Initialize(gameForm);

            Controls.InitializeControls(gameForm);

            Game.Initialize(gameForm);
            Game.Load();
            Game.Draw();

            Application.Run(gameForm);
        }
    }
}
