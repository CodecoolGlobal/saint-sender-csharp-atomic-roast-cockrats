using System.Threading.Tasks;
using System.Windows;
using SaintSender.Core.Interfaces;
using SaintSender.Core.Entities;
using SaintSender.Core.Services;

namespace SaintSender.DesktopUI.ViewModels
{
    internal class ComposeMailViewModel : BaseViewModel
    {
        #region Private Fields

        private MailComposeModel _mailComposeModel;

        private IComposeService _composeService;

        #endregion Private Fields

        #region Public Fields

        public string ToAddress
        {
            get => _mailComposeModel.ToAddress;
            set
            {
                if (_mailComposeModel.ToAddress != value)
                {
                    _mailComposeModel.ToAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Subject
        {
            get => _mailComposeModel.Subject;
            set
            {
                if (_mailComposeModel.Subject != value)
                {
                    _mailComposeModel.Subject = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Body
        {
            get => _mailComposeModel.Body;
            set
            {
                if (_mailComposeModel.Body != value)
                {
                    _mailComposeModel.Body = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Public Fields

        #region Public Functions

        public async Task Compose()
        {
            if (await _composeService.Compose(_mailComposeModel))
            {
                foreach (Window currentWindow in Application.Current.Windows)
                {
                    if (currentWindow.Name == "ComposeWindow") currentWindow.Close();
                }
            }
        }

        #endregion Public Functions

        #region Constructor

        public ComposeMailViewModel()
        {
            _mailComposeModel = new MailComposeModel();
            _composeService = new ComposeService();
        }

        #endregion Constructor
    }
}