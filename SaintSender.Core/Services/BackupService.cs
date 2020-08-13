using SaintSender.Core.Entities;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    internal class BackupService
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