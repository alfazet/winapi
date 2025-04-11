using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4
{
    public class Star
    {
        public Point Location { get; protected set; }
        public int ActualBrightness { get; protected set; }
        public int MaxBirghtness { get; protected set; }
        public float Radius { get; protected set; }
        private static Random _random = new Random();


        private int _factory = 1;
        public void ChangeStarBrightness()
        {
            if (ActualBrightness == MaxBirghtness)
                _factory = -1;
            if (ActualBrightness == 0)
                _factory = 1;

            ActualBrightness += _factory * 1;
        }

        public static Star CreateRandomStart(int maxX, int maxY, int maxBrightnes, int maxRadious)
        {

            var star = new Star();
            star.Location = new Point(_random.Next(1, maxX - 1), _random.Next(1, maxY - 1));
            star.MaxBirghtness = maxBrightnes;
            star.ActualBrightness = _random.Next(1, star.MaxBirghtness);
            star.Radius = _random.Next(1, maxRadious);
            return star;
        }

        public int GetTransparency()
        {
            var transparency =30+ (ActualBrightness * 225) / MaxBirghtness;
            return transparency;
        }

    }
}
