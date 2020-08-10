using System;
using SaintSender.Core.Entities;
using SaintSender.Core.Interfaces;
using SaintSender.Core.Services;

namespace SaintSender.DesktopUI.ViewModels
{
    class AddEmailWindowViewModel : BaseViewModel
    {
        #region Private Properties

        private EmailAccountModel _emailAccountModel;

        private ISignInService _signInService;

        #endregion

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

        #endregion

        #region Public Methods

        public void SignIn()
        {
            _signInService.SignIn(_emailAccountModel);
        }

        #endregion

        #region Constructor

        public AddEmailWindowViewModel()
        {
            _emailAccountModel = new EmailAccountModel();
            _signInService = new SignInService();
        }

        #endregion
    }
}