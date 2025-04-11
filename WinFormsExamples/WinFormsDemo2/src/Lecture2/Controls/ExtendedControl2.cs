using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture2.Controls
{
    public class ExtendedControl2:TextBox
    {
        public ExtendedControl2():base()
        {
            SetStyle(ControlStyles.UserPaint,true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(Text!=null && Text.ToLower().Contains("red"))
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, 3, ButtonBorderStyle.Solid, Color.Red, 3,
                ButtonBorderStyle.Solid, Color.Red, 3, ButtonBorderStyle.Solid, Color.Red, 3, ButtonBorderStyle.Solid);
            e.Graphics.DrawString(Text,this.Font,Brushes.Black,ClientRectangle.X+4,ClientRectangle.Y+5);
        }
    }
}
