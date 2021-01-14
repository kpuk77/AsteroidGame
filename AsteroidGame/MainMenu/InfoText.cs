﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    class InfoText
    { 
        private static Label __Label;

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
            MessageBox.Show("Алексей Ступин, 31 год, учусь в GeekBrains.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void TextVisible(bool status)
        {
            __Label.Visible = status;
        }
    }
}
