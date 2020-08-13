using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;
using Spire.Email.IMap;
using Spire.Email.Smtp;
using System;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    public class ComposeService : IComposeService
    {
        public async Task<bool> Compose(MailComposeModel mailComposeModel)
        {
            EmailAccountModel emailAccount = EmailAccountModel.Deserialize();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",
                587,
                emailAccount.EmailAddress,
                emailAccount.Password,
                ConnectionProtocols.StartTls
            );
            return await Task.Run(() =>
            {
                try
                {
                    smtpClient.SendOne(
                        emailAccount.EmailAddress,
                        mailComposeModel.ToAddress,
                        mailComposeModel.Subject,
                        mailComposeModel.Body);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            });
        }
    }
}