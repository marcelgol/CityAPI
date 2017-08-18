using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace City.API.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "marcelgol@gmail.com";
        private string _mailFrom = "marcelgol@gmail.com";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo} using LocalMailService");
            Debug.WriteLine($"SUbject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
