using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SMTPPractWork6.Models;
using SMTPPractWork6.Serivces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SMTPPractWork6.ViewModels
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
                await messageService.ShowErrorMessage(error);
                return;
            }

            try
            {
                await smtpService.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                await logService.LogExceptionAsync(ex.Message);
                await messageService.ShowErrorMessage(ex.Message);
            }
        }
    }
}
