using SaintSender.Core.Entities;

namespace SaintSender.Core.Interfaces
{
    public interface IComposeService
    {
        void Compose(MailComposeModel mailComposeModel);
    }
}