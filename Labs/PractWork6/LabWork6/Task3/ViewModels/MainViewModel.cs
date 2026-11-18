using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task3.Serivces;
using Task3.Views;

namespace Task3.ViewModels
{
    public partial class MainViewModel(
        SMTPService smtpService,
        LogService logService,
        MessageService messageService,
        MailValidator mailValidator
            ) : ObservableObject
    {
        [ObservableProperty]
        private string _recipientMailAddress = "jako6cMOHAPX@gmail.com";

        [RelayCommand]
        private async Task SendMessageAsync(string mail)
        {
            var (isValid, error) = mailValidator.IsValidMailAddressAsync(mail);
            if (!isValid)
            {
                messageService.ShowErrorMessage(error);
                return;
            }

            try
            {
                await smtpService.SendMailAsync(mail);
                AuthorizationWindow authorizationWindow = new();
                authorizationWindow.Show();
            }
            catch (Exception ex)
            {
                await logService.LogExceptionAsync(ex.Message);
                messageService.ShowErrorMessage(ex.Message);
            }
        }
    }
}
