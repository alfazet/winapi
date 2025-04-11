using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Lecture2.Controls
{
    public class PointConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType)
        {
            // Insert other ConvertTo operations here.
            //
            if (destinationType == typeof(InstanceDescriptor) &&
                value is Point)
            {
                Point pt = (Point) value;

                ConstructorInfo ctor = typeof(Point).GetConstructor(
                    new Type[] {typeof(int), typeof(int)});
                if (ctor != null)
                {
                    return new InstanceDescriptor(ctor, new object[] {pt.X, pt.Y});
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
