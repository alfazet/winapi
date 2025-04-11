using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControls1
{
    public partial class DetailsForm : Form
    {
        public DetailsForm(MyDataSet dataSet)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSet;
            bindingSource1.DataMember = "Users";
        }

        private void DetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
