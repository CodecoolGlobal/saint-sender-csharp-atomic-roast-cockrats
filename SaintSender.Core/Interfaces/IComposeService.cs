using SaintSender.Core.Entities;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    public interface IComposeService
    {
        Task<bool> Compose(MailComposeModel mailComposeModel);
    }
}