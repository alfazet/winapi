﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfTest
{
    public class ColorInfo
    {
        public string Name { get; set; }
        public string RgbInfo { get; set; }
        public Color Rgb { get; set; }
    }
    
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Color)
                return null;
            return new SolidColorBrush((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not SolidColorBrush)
                return null;
            return ((SolidColorBrush)value).Color;
        }
    }
}
