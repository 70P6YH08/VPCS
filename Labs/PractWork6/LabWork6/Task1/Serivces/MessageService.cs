using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Task1.Serivces
{
    public class MessageService
    {
        public void ShowSuccessSendMessage()
        {
            MessageBox.Show("Письмо принято почтовым сервером для отправки", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void ShowErrorMessage(string? errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
