using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form game_form = new Form();

            game_form.Width = 800;
            game_form.Height = 600;
            game_form.Text = "Asteroid game";
            game_form.MinimizeBox = false;
            game_form.MaximizeBox = false;
            game_form.FormBorderStyle = FormBorderStyle.Fixed3D;

            game_form.Show();

            Menu.Initialize(game_form);
            Menu.Load();
            Menu.Draw();

            Buttons.InitializeControls(game_form);
            Buttons.Draw();


            Game.Initialize(game_form);
            Game.Load();
            Game.Draw();

            Application.Run(game_form);
        }
    }
}
