using System;
using System.Collections.Generic;
using System.Text;

namespace SMTPPractWork6.Models
{
    public class Mail
    {
        public string? RecipientMailAddress { get; set; }
        public string? MailSubject { get; set; }
        public string? MailMessage { get; set; }
    }
}
