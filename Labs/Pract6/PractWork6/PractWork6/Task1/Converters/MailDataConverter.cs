using System.Globalization;
using System.Windows.Data;
using Task1.Models;

namespace Task1.Converters
{
    public class MailDataConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Mail
            {
                RecipientMailAddress = values[0] as string,
                MailSubject = values[1] as string,
                MailMessage = values[2] as string
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
