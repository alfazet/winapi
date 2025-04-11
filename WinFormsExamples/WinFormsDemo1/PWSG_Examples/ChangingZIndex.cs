using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWSG_Examples
{
    public partial class ChangingZIndex : Form
    {
        private const int BUTTON_WIDHT = 60;
        private const int BUTTON_HEIGHT = 30;
        private static int countAddButtonClick = 0;
        public ChangingZIndex()
        {
            InitializeComponent();
            pnlAddedControls.BackColor = TransparencyKey;

        }

        private void BtnAddControls_Click(object sender, EventArgs e)
        {
            countAddButtonClick++;
            AddButtons(countAddButtonClick % 2 == 0 ? pnlAddedControls : pnlTest2, CountControls());
            RefreshControlNumber();
        }

        private void AddButtons(Panel panel, int statIndex)
        {
            panel.Controls.Clear();

            var width = panel.Width;

            var numberOfControls2Add = int.Parse(textBox1.Text);

            var controlsInRow = width / BUTTON_WIDHT;


            for (int i = 0; i < numberOfControls2Add; i++)
            {
                var column = i % controlsInRow;
                var row = i / controlsInRow;

                Button button = new Button()
                {
                    Name = FormatButtonName(statIndex + i),
                    Text = (statIndex + i).ToString(),
                    Size = new Size(BUTTON_WIDHT, BUTTON_HEIGHT),
                    Location = new Point(column * BUTTON_WIDHT, row * BUTTON_HEIGHT),
                    TabIndex = i,
                    //inny sposób ustawiania
                    //Left = column*BUTTON_WIDHT,
                    //Top = row*BUTTON_HEIGHT
                };
                Debug.WriteLine($"Add button {button.Name} on location {button.Location.X}:{button.Location.Y} in {panel.Name}");
                panel.Controls.Add(button);
                panel.BringToFront();
                panel.Visible = true;
            }
        }

        private void BtnCountControls_Click(object sender, EventArgs e)
        {
            RefreshControlNumber(true);
        }

        private void RefreshControlNumber(bool showMessageBox = false)
        {
            var message = $"kontrolek na formie: {CountControls()}";
            if (showMessageBox)
                MessageBox.Show(message);
            this.Text = message;
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
            Control control = null;
            foreach (Control control1 in this.Controls)
            {
                if(!(control1 is Panel)) continue;
                var panel = control1 as Panel;
                if (!panel.HasChildren)
                {
                    MessageBox.Show("Brak dodanych przycisków");
                    return;
                }

                control = panel.Controls.Find(FormatButtonName(buttonNumber), false).FirstOrDefault();
                if (control == null)
                {
                    continue;
                }

                control.BackColor = Color.Aqua;
                control.Focus();
            }

        }

        private string FormatButtonName(int i)
        {
            return "btn" + i;
        }
    }
}
