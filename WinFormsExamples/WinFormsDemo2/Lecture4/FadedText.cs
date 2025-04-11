using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4
{
    public delegate void DrawingEnded(object sender, EventArgs eventArgs);

    public class FadedText
    {
        private string _text = "A long long time ago in a galaxy far, far away....";
        public event DrawingEnded DrawningEnd;

        public int NonFadeTicks { get; set; }
        public int FadeTicks { get; set; }
        private int _ticksFromStart;
        private int _fadeFactory;
        public Color Color { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }
        public Rectangle Rectangle { get; set; }
        private Font _font;
        public FadedText(Rectangle rectangle)
        {
            NonFadeTicks = 100;
            FadeTicks = 30;
            _fadeFactory = 250 / FadeTicks;
            Color = Color.Cyan;
            FontName = "Tahoma";
            FontSize = 55;
            Rectangle = rectangle;
        }


        public void Draw(Graphics graphics)
        {
            if(_ticksFromStart>2*FadeTicks+NonFadeTicks+1)
                return;
            if (_font == null)
                _font = new Font(FontName, FontSize);
            if (_ticksFromStart <= FadeTicks)
            {
                Brush brush = new SolidBrush(Color.FromArgb(_fadeFactory * _ticksFromStart, Color));
                graphics.DrawString(_text, _font, brush, Rectangle);
            }
            else if (_ticksFromStart > FadeTicks && _ticksFromStart < FadeTicks + NonFadeTicks)
            {
                graphics.DrawString(_text, _font, new SolidBrush(Color), Rectangle);
            }
            else if (_ticksFromStart >= FadeTicks + NonFadeTicks)
            {
                Brush brush = new SolidBrush(Color.FromArgb( _fadeFactory * ((2*FadeTicks+NonFadeTicks)-_ticksFromStart), Color));
                graphics.DrawString(_text, _font, brush, Rectangle);
            }

            if (_ticksFromStart == 2 * FadeTicks + NonFadeTicks)
            {
                DrawningEnd?.Invoke(this,new EventArgs());
            }
        }
    }
}
