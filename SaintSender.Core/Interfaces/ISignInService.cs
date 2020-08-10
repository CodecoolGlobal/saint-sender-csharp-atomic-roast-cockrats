using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaintSender.Core.Entities;

namespace SaintSender.Core.Interfaces
{
    public interface ISignInService
    {
        bool SignIn(EmailAccountModel emailAccount);
    }
}
