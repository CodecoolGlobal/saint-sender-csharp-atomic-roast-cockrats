using System.Threading.Tasks;
using System.Windows;
using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;
using SaintSender.Core.Services;

namespace SaintSender.DesktopUI.ViewModels
{
    internal class AddEmailWindowViewModel : BaseViewModel
    {
        #region Private Properties

        private EmailAccountModel _emailAccountModel;

        private ISignInService _signInService;

        #endregion Private Properties

        #region Public Properties

        public string EmailAddress
        {
            get => _emailAccountModel.EmailAddress;
            set
            {
                if (_emailAccountModel.EmailAddress != value)
                {
                    _emailAccountModel.EmailAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _emailAccountModel.Password;
            set
            {
                if (_emailAccountModel.Password != value)
                {
                    _emailAccountModel.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Public Properties

        #region Public Methods

        #endregion Public Properties

        #region Public Methods

        public async Task SignIn()
        {
            if (await _signInService.SignIn(_emailAccountModel))
            {
                foreach (Window currentWindow in Application.Current.Windows)
                {
                    if (currentWindow.Name == "AddEmailWindow") currentWindow.Close();
                }
            }
        }

        #endregion Public Methods

        #region Constructor

        public AddEmailWindowViewModel()
        {
            _emailAccountModel = new EmailAccountModel();
            _signInService = new SignInService();
        }

        #endregion Constructor
    }
}