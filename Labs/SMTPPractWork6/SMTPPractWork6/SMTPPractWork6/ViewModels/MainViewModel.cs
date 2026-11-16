using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SMTPPractWork6.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPPractWork6.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private SMTPService _smtpService;

        [ObservableProperty]
        private string _mail;

        [ObservableProperty]
        private string _mailText;

        [ObservableProperty]
        private string _mailHeader;

        public MainViewModel(SMTPService smtpService)
        {
            _smtpService = smtpService;
        }

        [RelayCommand]
        private async Task SendMessageAsync()
        {
            await _smtpService.SendMailAsync();
        }
    }
}
