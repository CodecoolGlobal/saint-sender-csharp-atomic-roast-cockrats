using System;
using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;

namespace SaintSender.Core.Services
{
    public class ComposeService : IComposeService
    {
        public void Compose(MailComposeModel mailComposeModel)
        {
            Console.WriteLine(mailComposeModel.ToString());
        }
    }
}