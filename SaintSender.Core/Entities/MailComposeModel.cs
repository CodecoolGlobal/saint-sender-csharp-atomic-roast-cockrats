namespace SaintSender.Core.Entities
{
    public class MailComposeModel
    {
        #region Public Fields

        public string ToAddress { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        #endregion Public Fields

        #region Public Methods

        public override string ToString()
        {
            return "Target address is: " + this.ToAddress + " subject is: " + this.Subject + " and the message is: " +
                   this.Body;
        }

        #endregion Public Methods
    }
}