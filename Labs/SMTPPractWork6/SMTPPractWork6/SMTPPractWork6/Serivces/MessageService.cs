using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SMTPPractWork6.Serivces
{
    public class MessageService
    {
        public async Task ShowSuccessSendMessage()
        {
            MessageBox.Show("Письмо принято почтовым сервером для отправки", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public async Task ShowErrorMessage(string? errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
