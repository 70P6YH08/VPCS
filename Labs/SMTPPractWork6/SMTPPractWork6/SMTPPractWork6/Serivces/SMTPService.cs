using MimeKit;
using SMTPPractWork6.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SMTPPractWork6.Serivces
{
    public class SMTPService
    {

        //ЛОГИН student[NN]@act29.ru (NN in 1,2,3,4,5,6,7,8,9,10,11,12,13,14)
        //ПАРОЛЬ Arcotel2026.
        //ПОРТ 465
        //ПРИМЕР student1@act29.ru
        public string host = "student6@act29.ru";
        public string sender = "no-reply@example.com";
        public string password = "Arcotel2026.";
        public int port = 465;

        //private MainViewModel _mainViewModel;

        //public SMTPService(MainViewModel mainViewModel)
        //{
        //    _mainViewModel = mainViewModel;
        //}

        public async Task SendMailAsync()
        {
            SmtpClient smtpClient = new();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Имя отправителя", sender));
            message.To.Add(new MailboxAddress("Имя получателя", host));

            message.Subject = ""
        }
    }
}
