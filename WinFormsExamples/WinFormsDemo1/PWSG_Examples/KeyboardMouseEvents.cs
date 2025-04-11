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
    public partial class KeyboardMouseEvents : Form
    {
        public KeyboardMouseEvents()
        {
            InitializeComponent();
            MouseMove += Form1_MouseMove;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("TextBox1_KeyDown");
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("TextBox1_KeyPress");
            if (e.KeyChar == 'm') e.Handled = true;

        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("TextBox1_KeyUp");
        }

        private void TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine("TextBox1_PreviewKeyDown");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.Location.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool toogle = !(this.button1.Tag == null ? false : ((bool)this.button1.Tag));
            foreach (var control in this.Controls)
            {
                ToogleShowMousePositionOverContol(control as Control, toogle);
            }

            this.button1.Tag = toogle;

        }

        private void ToogleShowMousePositionOverContol(Control control, bool toogle)
        {
            if (control.HasChildren)
            {
                foreach (var childControl in control.Controls)
                {
                    ToogleShowMousePositionOverContol((Control)childControl, toogle);
                }
            }

            if (toogle)
            {
                control.MouseMove += Form1_MouseMove;
            }
            else
            {
                control.MouseMove -= Form1_MouseMove;
            }
        }
    }
}
