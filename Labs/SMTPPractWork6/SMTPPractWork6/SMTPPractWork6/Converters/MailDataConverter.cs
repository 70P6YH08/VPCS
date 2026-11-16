using SMTPPractWork6.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace SMTPPractWork6.Converters
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
