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
    public partial class Buttons : Form
    {
        public Buttons()
        {
            InitializeComponent();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("CheckedChange");
            Debug.WriteLine($"CheckState {(sender as CheckBox).CheckState}");
            Debug.WriteLine($"Checked {(sender as CheckBox).Checked}");
        }

        private void CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("CheckStateChanged");
            Debug.WriteLine($"CheckState {(sender as CheckBox).CheckState}");
            Debug.WriteLine($"Checked {(sender as CheckBox).Checked}");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I was clicked!");
        }
    }
}
