using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task3.Serivces;

namespace Task3.ViewModels
{
    public partial class AuthorizationViewModel(
        SMTPService smtpService,
        LogService logService,
        MessageService messageService
            ) : ObservableObject
    {
        [ObservableProperty]
        private string? _code;

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
