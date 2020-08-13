using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;
using SaintSender.Core.Services;
using System.Threading.Tasks;

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

        public async Task<bool> SignIn()
        {
            return await _signInService.SignIn(_emailAccountModel);
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