using System;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form game_form = new Form();

            game_form.Width = 1000;
            game_form.Height = 600;
            game_form.Text = "Asteroid game";
            game_form.MinimizeBox = false;
            game_form.MaximizeBox = false;
            game_form.FormBorderStyle = FormBorderStyle.Fixed3D;

            if (game_form.Width > 1000 || game_form.Height > 1000 || game_form.Width < 0 || game_form.Height < 0)
                throw new ArgumentOutOfRangeException();

            game_form.Show();

            Menu.Initialize(game_form);
            Menu.Load();
            Menu.Draw();
            InfoText.Initialize(game_form);

            Buttons.InitializeControls(game_form);

            Game.Initialize(game_form);
            Game.Load();
            Game.Draw();

            Application.Run(game_form);
        }
    }
}
