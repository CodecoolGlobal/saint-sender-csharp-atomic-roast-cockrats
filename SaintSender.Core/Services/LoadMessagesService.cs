using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaintSender.Core.Entities;
using Spire.Email;
using Spire.Email.Pop3;

namespace SaintSender.Core.Services
{
    public class LoadMessagesService
    {
        private Pop3Client _pop3Client;

        public LoadMessagesService()
        {
            EmailAccountModel emailAccountModel = EmailAccountModel.Deserialize();
            _pop3Client = new Pop3Client(
                    "pop.gmail.com",
                    995,
                    emailAccountModel.EmailAddress,
                    emailAccountModel.Password)
                {EnableSsl = true};
        }

        public Task<List<MailMessage>> GetMessages()
        {

            return Task.Run(() =>
            {
                _pop3Client.Connect();
                _pop3Client.Login();
                return _pop3Client.GetAllMessages().Select(message => _pop3Client.GetMessage(message.SequenceNumber)).Reverse().Take(20).ToList();
            });
        }
    }
}