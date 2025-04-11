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
    public partial class GroupFlowForm : Form
    {
        public GroupFlowForm()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                this.flowLayoutPanel1.Controls.Add(new Button
                {
                    Name = "btn" + i,
                    Size = new Size(30, 30),
                    Text = i.ToString()
                });
            }

            this.flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
        }
    }
}
