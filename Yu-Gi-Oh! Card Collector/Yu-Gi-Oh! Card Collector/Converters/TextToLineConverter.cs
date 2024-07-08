using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yu_Gi_Oh__Card_Collector.Converters
{
    public class TextToLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = 0;
            string[] characters = { "&", ".", "/", ",", "^", "!", "?", "+" };

            if (!string.IsNullOrEmpty((string)value))
            {
                x += 85;

                if (value.ToString().Length > 6)
                {
                    x += 85;
                }

                for (int i = 0; i < characters.Length; i++)
                {
                    if (value.ToString().Contains(characters[i]))
                    {
                        x += 85;
                        break;
                    }
                }

                for (int i = 0; i < value.ToString().Length; i++)
                {
                    if (char.IsUpper(value.ToString()[i]))
                    {
                        x += 85;
                        break;
                    }
                }
            }

            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
