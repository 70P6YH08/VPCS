using System.Text.RegularExpressions;

namespace Task3.Services
{
    public class MailValidator
    {
        private const string _mailRegex = @"^[a-zA-Z0-9_]{3,}@[a-zA-Z0-9]{2,}\.[a-zA-Z]{2,}$";
        public (bool isValid, string? error) IsValidMailAddressAsync(string? mailAddress)
        {
            if (String.IsNullOrWhiteSpace(mailAddress))
                return (false, "Пустая почта");

            if (!Regex.IsMatch(mailAddress.Trim(), _mailRegex))
                return (false, "Некорректная почта");

            return (true, null);
        }
    }
}
