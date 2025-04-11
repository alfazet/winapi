using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWSG_Examples
{
    public partial class AddingControlsFromCode : Form
    {
        private const int BUTTON_WIDHT = 60;
        private const int BUTTON_HEIGHT = 30;
        public AddingControlsFromCode()
        {
            InitializeComponent();
        }

        private void BtnAddControls_Click(object sender, EventArgs e)
        {
            pnlAddedControls.Controls.Clear();

            var width = pnlAddedControls.Width;

            var numberOfControls2Add = int.Parse(textBox1.Text);

            var controlsInRow = width / BUTTON_WIDHT;


            for (int i = 0; i < numberOfControls2Add; i++)
            {
                var column = i % controlsInRow;
                var row = i / controlsInRow;
                Button button = new Button()
                {
                    Name =FormatButtonName(i),
                    Text = i.ToString(),
                    Size = new Size(BUTTON_WIDHT, BUTTON_HEIGHT),
                    Location = new Point(column * BUTTON_WIDHT, row * BUTTON_HEIGHT)
                    //inny sposób ustawiania
                    //Left = column*BUTTON_WIDHT,
                    //Top = row*BUTTON_HEIGHT
                };
                pnlAddedControls.Controls.Add(button);
            }

        }

        private void BtnCountControls_Click(object sender, EventArgs e)
        {
            //Count controls only in first level of form
            MessageBox.Show($"kontrolek na formie: {this.Controls.Count} rekurencyjnie kontrolek na formie {CountControls()}");
        }


        private int CountControls()
        {
            int count = 0;
            if (!HasChildren) return count;
            foreach (Control control in Controls)
            {
                count += CountChildsControls(control) + 1;
            }

            return count;
        }

        private int CountChildsControls(Control control)
        {
            if (control == null) return 0;
            if (!control.HasChildren) return 0;

            int count = 0;
            foreach (Control childControl in control.Controls)
            {
                count += CountChildsControls(childControl) + 1;
            }

            return count;
        }


        private void BtnFind_Click(object sender, EventArgs e)
        {
            var buttonNumber = int.Parse(txtFind.Text);

            if (!pnlAddedControls.HasChildren)
            {
                MessageBox.Show("Brak dodanych przycisków");
                return;
            }

            var control = pnlAddedControls.Controls.Find(FormatButtonName(buttonNumber), false).FirstOrDefault();
            if (control == null)
            {
                MessageBox.Show("Nieznaleziono przycisku");
                return;
            }

            control.BackColor = Color.Aqua;

        }


        private string FormatButtonName(int i)
        {
            return "btn" + i;
        }
    }
}
