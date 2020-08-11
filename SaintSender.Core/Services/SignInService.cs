using System;
using System.Threading.Tasks;
using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;
using Spire.Email.Pop3;

namespace SaintSender.Core.Services
{
    public class SignInService : ISignInService
    {
        public async Task<bool> SignIn(EmailAccountModel emailAccount)
        {
            return await CreateConnection(emailAccount);
        }

        private async Task<bool> CreateConnection(EmailAccountModel emailAccount)
        {
            Pop3Client client = new Pop3Client(
                "pop.gmail.com",
                995,
                emailAccount.EmailAddress,
                emailAccount.Password);
            client.EnableSsl = true;

            return await Task.Run(() =>
            {
                try
                {
                    client.Connect();
                    client.Login();
                    emailAccount.Serialize();
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