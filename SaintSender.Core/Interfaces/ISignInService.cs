using SaintSender.Core.Entities;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    public interface ISignInService
    {
        Task<bool> SignIn(EmailAccountModel emailAccount);
    }
}