using SaintSender.Core.Services;
using Spire.Email.Pop3;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ListMailsViewModel : BaseViewModel
    {
        #region Private Fields

        private Pop3MessageInfoCollection _messageInfos { get; set; }

        private LoadMessagesService LoadMessagesService { get; set; }

        #endregion Private Fields

        #region Public Fields

        public Pop3MessageInfoCollection MessageInfos
        {
            get => _messageInfos;
            set
            {
                if (_messageInfos != value)
                {
                    _messageInfos = value;
                }
            }
        }

        #endregion Public Fields

        #region Constructor

        public ListMailsViewModel()
        {
            this._messageInfos = new Pop3MessageInfoCollection();
            this.LoadMessagesService = new LoadMessagesService();
            /*
            this._messageInfos = LoadMessagesService.GetMessages();
            */
        }

        #endregion Constructor
    }
}