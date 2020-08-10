namespace SaintSender.Core.Entities
{
    public class EmailAccountModel
    {
        #region Public Properties

        public string EmailAddress { get; set; }
        public string Password { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{EmailAddress};{Password}";
        }

        #endregion
    }
}