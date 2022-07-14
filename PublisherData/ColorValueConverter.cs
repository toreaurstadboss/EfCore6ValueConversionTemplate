using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Drawing;
using System.Linq.Expressions;

namespace PublisherData
{
 
    public class ColorValueConverter : ValueConverter<Color, string>
    {
        private static Expression<Func<Color, string>> ColorString =
            c => new string(c.Name);
        static Expression<Func<string, Color>> ColorStruct =
            s => Color.FromName(s);

        public ColorValueConverter() : base(ColorString, ColorStruct) { 
        }
    }

}
