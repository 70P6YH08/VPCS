using System;
using System.Security.Cryptography;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using Task2.Serivces;

namespace Task2.Serivces
{
    public class SMTPService(LogService logService, MessageService messageService)
    {
        //private readonly LogService _logService = logService;
        //private readonly MessageService _messageService = messageService;

        //ЛОГИН student[NN]@act29.ru (NN in 1,2,3,4,5,6,7,8,9,10,11,12,13,14)
        //ПАРОЛЬ Arcotel2026.
        //ПОРТ 465
        //ПРИМЕР student1@act29.ru

        private readonly string _senderMailAddress = "student8@act29.ru";
        private readonly string _password = "Arcotel2026.";
        private readonly int _port = 465;
        private readonly string _host = "act29.ru";

        public DateTime start;
        public int code;

        public async Task SendMailAsync(string mail)
        {
            if (String.IsNullOrWhiteSpace(mail))
                throw new ArgumentException(
                    "Некорректный адрес получателя: ",
                    nameof(mail)
                    );

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Имя отправителя", _senderMailAddress));
            message.To.Add(new MailboxAddress("Имя получателя", mail.Trim()));

            message.Subject = "Код";

            code = RandomNumberGenerator.GetInt32(100000,999999);

            start = DateTime.Now;

            var messageBody = new BodyBuilder
            {
                HtmlBody = $"""
                    <html>
                        <body
                            <h2>Код: {code}</h2>
                            <h4>Время действия кода: 5 минут</h4>
                        </body>
                    </html>
                """
            };

            message.Body = messageBody.ToMessageBody();

            try
            {
                using (SmtpClient smtpClient = new())
                {
                    await smtpClient.ConnectAsync(_host, _port);

                    await smtpClient.AuthenticateAsync(_senderMailAddress, _password);

                    await smtpClient.SendAsync(message);

                    await smtpClient.DisconnectAsync(true);
                }

                messageService.ShowSuccessSendMessage("Письмо принято почтовым сервером для отправки");
            }

            catch (SmtpCommandException ex)
            {
                await logService.LogExceptionAsync(ex.ToString());
                messageService.ShowErrorMessage(ex.Message);
            }

            catch (SmtpProtocolException ex)
            {
                await logService.LogExceptionAsync(ex.ToString());
                messageService.ShowErrorMessage(ex.Message);
            }

            catch (Exception ex)
            {
                await logService.LogExceptionAsync(ex.ToString());
                messageService.ShowErrorMessage("Не удалось отправить письмо " + ex.Message);
            }
        }

        public void CheckCodeAsync(int checkCode)
        {
            if(DateTime.Now - start > TimeSpan.FromMinutes(5))
            {
                messageService.ShowErrorMessage("Код просрочен!");
                return;
            }
            if (checkCode.Equals(code))
                messageService.ShowSuccessSendMessage("Код получен!");
            else
                messageService.ShowErrorMessage("Неверный код");
        }
    }
}
