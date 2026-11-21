using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task2.Serivces;

namespace Task2.ViewModels
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
        private string? _code;

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
            }
            catch (Exception ex)
            {
                await logService.LogExceptionAsync(ex.Message);
                messageService.ShowErrorMessage(ex.Message);
            }
        }
        [RelayCommand]
        private async Task CheckCodeAsync(string codeString)
        {
            if (String.IsNullOrWhiteSpace(codeString))
            {
                messageService.ShowErrorMessage("Код не может быть пустым");
                return;
            }

            int code = Convert.ToInt32(codeString);

            try
            {
                smtpService.CheckCodeAsync(code);
            }
            catch (Exception ex)
            {
                await logService.LogExceptionAsync(ex.Message);
                messageService.ShowErrorMessage(ex.Message);
            }
        }
    }
}
