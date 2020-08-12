using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SaintSender.Core.Entities;
using Spire.Email;
using Spire.Email.Pop3;

namespace SaintSender.Core.Services
{
    public class LoadMessagesService
    {
        private readonly Pop3Client _pop3Client;

        public LoadMessagesService()
        {
            EmailAccountModel emailAccountModel = EmailAccountModel.Deserialize();
            _pop3Client = new Pop3Client(
                    "pop.gmail.com",
                    995,
                    emailAccountModel.EmailAddress,
                    emailAccountModel.Password)
                {EnableSsl = true};
            _pop3Client.Connect();
            _pop3Client.Login();
        }

        public List<MailMessage> GetMessages()
        {
            return _pop3Client.GetAllMessages().Select(message => _pop3Client.GetMessage(message.SequenceNumber)).ToList();
        }
    }
}