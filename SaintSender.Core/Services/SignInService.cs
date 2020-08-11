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
            return false;
        }

        public void CreateConnection(EmailAccountModel emailAccount)
        {
            Pop3Client pop = new Pop3Client();
        }
    }
}