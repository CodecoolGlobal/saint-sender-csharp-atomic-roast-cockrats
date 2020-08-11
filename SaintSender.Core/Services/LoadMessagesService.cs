using System.IO;
using SaintSender.Core.Entities;
using Spire.Email.Pop3;

namespace SaintSender.Core.Services
{
    public class LoadMessagesService
    {
        private readonly Pop3Client _pop3Client;

        public LoadMessagesService()
        {
            if (File.Exists(@"\data\EmailAccount.bin"))
            {
                EmailAccountModel emailAccountModel = EmailAccountModel.Deserialize();
                _pop3Client = new Pop3Client(
                        "pop.gmail.com",
                        995,
                        emailAccountModel.EmailAddress,
                        emailAccountModel.Password)
                    { EnableSsl = true };
                _pop3Client.Connect();
                _pop3Client.Login();
            }
        }

        public Pop3MessageInfoCollection GetMessages()
        {
            return _pop3Client.GetAllMessages();
        }
    }
}