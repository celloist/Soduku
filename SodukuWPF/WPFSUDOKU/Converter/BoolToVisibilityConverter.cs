using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPFSUDOKU
{
    /// <summary>
    /// Converts a bool into a Visibility value, showing if true and hiding if false.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts to the target value
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="targetType">The type to convert to</param>
        /// <param name="parameter">The parameter given</param>
        /// <param name="culture">The current culture information for localization</param>
        /// <returns>A converted value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Converts back to the original value
        /// </summary>
        /// <param name="value">The converted value</param>
        /// <param name="targetType">The type to convert to</param>
        /// <param name="parameter">The parameter given</param>
        /// <param name="culture">The current culture information for localization</param>
        /// <returns>The original object</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
