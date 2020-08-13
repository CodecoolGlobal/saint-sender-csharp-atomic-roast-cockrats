using Spire.Email;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SaintSender.Core.Entities
{
    [Serializable]
    public class BackUpModel
    {
        private static readonly string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BackUp.bin");

        private List<MailMessage> _mailMessages;

        public BackUpModel(List<MailMessage> mailMessages)
        {
            _mailMessages = mailMessages;
        }

        public BackUpModel()
        {

        }

        public async Task<bool> Serialize()
        {
            return await Task.Run(() =>
            {
                try
            {
                if(File.Exists(path))
                {
                    File.Delete(path);
                }
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            });
            
        }

        public static BackUpModel Deserialize()
        {
            BackUpModel backUpModel = new BackUpModel();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            backUpModel = (BackUpModel) formatter.Deserialize(stream);
            stream.Close();
            return backUpModel;
        }
    }
}
