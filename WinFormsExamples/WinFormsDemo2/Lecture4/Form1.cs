using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture4
{

    public partial class Form1 : Form
    {
        private IEnumerable<Star> _stars;
        private Timer _timer = new Timer();
        private Bitmap _image;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;


        }

        protected override void OnShown(EventArgs e)
        {
            CreateStars(1000);
            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
            _timer.Start();
            _image= new Bitmap(ClientSize.Width, ClientSize.Height);
            pictureBox1.Image = _image;
            this.DoubleBuffered = true;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            CreateSky(_image);
            pictureBox1.Image = _image;

            foreach (var star in _stars)
            {
                star.ChangeStarBrightness();
            }

            var graphics = Graphics.FromImage(pictureBox1.Image);

            DrawStars(graphics);
            WriteIntroText(graphics, 60);
            DrawStarWarsLogo(graphics, 100);
            DrawEndText(graphics, 100);


            pictureBox1.Refresh();
        }

        private void DrawStars(Graphics graphics)
        {
            foreach (Star star in _stars)
            {
                //Debug.WriteLine(Color.FromArgb(star.GetTransparency(), Color.White).A);
                graphics.FillEllipse(new SolidBrush(Color.FromArgb(star.GetTransparency(),Color.White)),(float)star.Location.X-star.Radius/2,(float)star.Location.Y-star.Radius/2,star.Radius,star.Radius );
            }
        }

        private void DrawEndText(Graphics graphics, int i)
        {
        }

        private void DrawStarWarsLogo(Graphics graphics, int i)
        {
        }

        private int _intoTextBrightness = 1;
        private int _intoTextBrightnessFactor = 1;
        private void WriteIntroText(Graphics graphics, int i)
        {
            if (_intoTextBrightness < 0)
                return;
            var font = new Font("Tahoma", 55);
            _intoTextBrightness = (_intoTextBrightness) + ( _intoTextBrightnessFactor * (250 / i));
            if (_intoTextBrightness > 800)
                _intoTextBrightnessFactor = -1;
            if (_intoTextBrightness < 0)
                return;


            var brush = new SolidBrush(Color.FromArgb(_intoTextBrightness > 250 ? 255 : _intoTextBrightness, Color.CornflowerBlue));
            graphics.DrawString("A long long time ago in a galaxy far, far away....", font, brush, new RectangleF(200,300,ClientSize.Width-400,ClientSize.Height-400));
        }

        private void CreateStars(int starNumber)
        {
            List<Star> stars = new List<Star>();
            for (int i = 0; i < starNumber; i++)
            {
                stars.Add(Star.CreateRandomStart(this.ClientSize.Width, this.ClientSize.Height, 40, 5));
            }

            _stars = stars;
        }

        private int i = 1;
        public void CreateSky(Bitmap bitmap)
        {
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Black);
                graphics.Transform.RotateAt(10, new PointF(1.0f, 2.0f));
                graphics.Dispose();
            }
            Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);

            foreach (var star in _stars)
            {
                Color color = Color.FromArgb(star.GetTransparency(), Color.White);
                //Debug.WriteLine(color.A);
                bitmap.SetPixel(star.Location.X, star.Location.Y, color);
                bitmap.SetPixel(star.Location.X + 1, star.Location.Y, color);
                bitmap.SetPixel(star.Location.X, star.Location.Y - 1, color);
                bitmap.SetPixel(star.Location.X - 1, star.Location.Y, color);
                bitmap.SetPixel(star.Location.X, star.Location.Y - 1, color);
                //star.ChangeStarBrightness();
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
        }
    }
}
