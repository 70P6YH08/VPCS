using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task3.Services;

namespace Task3.ViewModels
{
    public partial class AuthorizationViewModel(
        SMTPService smtpService,
        LogService logService,
        MessageService messageService
            ) : ObservableObject
    {

        public string Email { get; set; } = null!;

        [ObservableProperty]
        private string? _code;

        private List<int> _activatedCodes = new();

        [RelayCommand]
        private async Task CheckCodeAsync(string codeString)
        {
            if (String.IsNullOrWhiteSpace(codeString))
            {
                messageService.ShowErrorMessage("Код не может быть пустым");
                return;
            }

            if (codeString.Any(c => !char.IsDigit(c)))
            {
                messageService.ShowErrorMessage("Лишние символы");
                return;
            }

            int code = Convert.ToInt32(codeString);

            try
            {
                smtpService.CheckCodeAsync(code, _activatedCodes);
            }
            catch (Exception ex)
            {
                await logService.LogExceptionAsync(ex.Message);
                messageService.ShowErrorMessage(ex.Message);
            }
        }

        [RelayCommand]
        private async Task RepeatedSendCodeAsync()
        {
            await smtpService.SendMailAsync(Email);
        }
    }
}
