using System;

namespace SaintSender.Core.Entities
{
    [Serializable]
    public class MailModel
    {
        #region Public Fields

        public string From;
        public string To;
        public DateTime Date;
        public string Subject;
        public string Body;

        #endregion

        #region Constructor

        public MailModel(string from, string to, DateTime date, string subject, string body)
        {
            From = from;
            To = to;
            Date = date;
            Subject = subject;
            Body = body;
        }

        #endregion
    }
}