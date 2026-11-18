using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task1.Models;
using Task1.Serivces;

namespace Task1.ViewModels
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

        [ObservableProperty]
        private string? _mailSubject;

        [ObservableProperty]
        private string? _mailMessage;

        [RelayCommand]
        private async Task SendMessageAsync(Mail mail)
        {
            var (isValid, error) = mailValidator.IsValidMailAddressAsync(mail.RecipientMailAddress);
            if (!isValid)
            {
                messageService.ShowErrorMessage(error);
                return;
            }

            try
            {
                await smtpService.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                await logService.LogExceptionAsync(ex.Message);
                messageService.ShowErrorMessage(ex.Message);
            }
        }
    }
}
