using System;
using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;

namespace SaintSender.Core.Services
{
    public class SignInService : ISignInService
    {
        public bool SignIn(EmailAccountModel emailAccount)
        {
            Console.WriteLine(emailAccount.ToString());
            return false;
        }
    }
}
