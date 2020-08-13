using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaintSender.Core.Entities
{
    [Serializable]
    public class EmailAccountModel
    {
        #region Public Properties

        public string EmailAddress { get; set; }
        public string Password { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void Serialize()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName +
                       @"\data\EmailAccount.bin";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static EmailAccountModel Deserialize()
        {
            EmailAccountModel emailAccountModel = new EmailAccountModel();
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName +
                          @"\data\EmailAccount.bin";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            emailAccountModel = (EmailAccountModel)formatter.Deserialize(stream);
            stream.Close();
            return emailAccountModel;
        }

        public override string ToString()
        {
            return $"{EmailAddress};{Password}";
        }

        #endregion Public Methods
    }
}