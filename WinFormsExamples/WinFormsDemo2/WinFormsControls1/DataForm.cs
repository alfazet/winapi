using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControls1
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DetailsForm(myDataSet).ShowDialog(this);
        }
    }
}
