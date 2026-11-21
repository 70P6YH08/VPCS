using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Task3.Services
{
    public class MessageService
    {
        public void ShowSuccessSendMessage(string? successMessage = null)
        {
            MessageBox.Show(successMessage, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void ShowErrorMessage(string? errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
