using System;
using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;
using Spire.Email.Pop3;

namespace SaintSender.Core.Services
{
    public class SignInService : ISignInService
    {
        public bool SignIn(EmailAccountModel emailAccount)
        {
            Console.WriteLine(emailAccount.ToString());
            emailAccount.Serialize();
            //CreateConnection(emailAccount);
            return false;
        }

        private void CreateConnection(EmailAccountModel emailAccount)
        {
            Pop3Client client = new Pop3Client(
                "pop.gmail.com",
                995,
                emailAccount.EmailAddress,
                emailAccount.Password);
            
            try
            {
                client.Connect();
                client.Login();
                Console.WriteLine("Connected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}