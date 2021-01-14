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
            Form menu_form = new Form();

            InitializeForms(game_form);
            InitializeForms(menu_form);

            menu_form.Show();
            game_form.Show();
            

            Menu.Initialize(menu_form);
            Menu.Load();
            Menu.Draw();

            Buttons.InitializeControls(menu_form);
            Buttons.Draw();


            Game.Initialize(game_form);
            Game.Load();
            Game.Draw();

            Application.Run(menu_form);
        }

        private static void InitializeForms(Form Form)
        {
            Form.Width = 800;
            Form.Height = 600;
            Form.Text = "Asteroid game";
            Form.MinimizeBox = false;
            Form.MaximizeBox = false;
            Form.FormBorderStyle = FormBorderStyle.Fixed3D;
        }
    }
}
