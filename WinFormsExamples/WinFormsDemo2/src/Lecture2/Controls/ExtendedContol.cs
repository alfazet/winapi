using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture2.Controls
{
    public class ExtendedContol:TextBox
    {
        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        struct RECT
        {
            public int left, top, right, bottom;
        }
        struct NCCALSIZE_PARAMS
        {
            public RECT newWindow;
            public RECT oldWindow;
            public RECT clientWindow;
            IntPtr windowPos;
        }
        float clientPadding = 2;
        float actualBorderWidth = 4;
        Color borderColor = Color.Red;
        public ExtendedContol() : base()
        {

        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    if (Text.Contains("Red"))
        //        e.Graphics.DrawRectangle(new Pen(Brushes.Red), 30, 30, 30, 30);
        //}

        protected override void WndProc(ref Message m)
        {
            //We have to change the clientsize to make room for borders
            //if not, the border is limited in how thick it is.
            if (m.Msg == 0x83) //WM_NCCALCSIZE   
            {
                if (m.WParam == IntPtr.Zero)
                {
                    RECT rect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                    rect.left += (int)clientPadding;
                    rect.right -= (int)clientPadding;
                    rect.top += (int)clientPadding;
                    rect.bottom -= (int)clientPadding;
                    Marshal.StructureToPtr(rect, m.LParam, false);
                }
                else
                {
                    NCCALSIZE_PARAMS rects = (NCCALSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALSIZE_PARAMS));
                    rects.newWindow.left += (int)clientPadding;
                    rects.newWindow.right -= (int)clientPadding;
                    rects.newWindow.top += (int)clientPadding;
                    rects.newWindow.bottom -= (int)clientPadding;
                    Marshal.StructureToPtr(rects, m.LParam, false);
                }
            }
            if (m.Msg == 0x85) //WM_NCPAINT    
            {
                IntPtr wDC = GetWindowDC(Handle);
                using (Graphics g = Graphics.FromHdc(wDC))
                {
                    ControlPaint.DrawBorder(g, new Rectangle(0, 0, Size.Width, Size.Height), borderColor, (int)actualBorderWidth, ButtonBorderStyle.Solid,
                        borderColor, (int)actualBorderWidth, ButtonBorderStyle.Solid, borderColor, (int)actualBorderWidth, ButtonBorderStyle.Solid,
                        borderColor, (int)actualBorderWidth, ButtonBorderStyle.Solid);
                }
                return;
            }
            base.WndProc(ref m);
        }
    }
}
