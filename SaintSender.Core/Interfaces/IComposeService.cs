using System.Threading.Tasks;
using SaintSender.Core.Entities;

namespace SaintSender.Core.Interfaces
{
    public interface IComposeService
    {
        Task<bool> Compose(MailComposeModel mailComposeModel);
    }
}