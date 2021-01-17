using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    class InfoText
    {
        private static Label __Label;
        public static bool Visible
        {
            get => __Label.Visible;
            set => __Label.Visible = value;
        }

        public static void Initialize(Form form)
        {
            __Label = new Label();
            __Label.Size = new Size(180, 25);
            __Label.Text = "Алексей Ступин. Версия: 0.0.1";
            __Label.TextAlign = ContentAlignment.MiddleCenter;
            __Label.BackColor = Color.Transparent;
            __Label.Location = new Point(form.ClientSize.Width - __Label.Width, form.ClientSize.Height - __Label.Height);
            form.Controls.Add(__Label);

            __Label.Click += __Label_Click;
        }

        private static void __Label_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Алексей Ступин, 31 год, учусь в GeekBrains.",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
