using SaintSender.Core.Entities;
using Spire.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    class BackupService
    {
        public async Task<bool> BackUp(BackUpModel backUpModel)
        {

            if (await backUpModel.Serialize())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
