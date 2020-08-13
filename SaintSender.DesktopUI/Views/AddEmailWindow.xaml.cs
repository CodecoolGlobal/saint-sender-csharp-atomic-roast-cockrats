using SaintSender.DesktopUI.ViewModels;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for AddEmail.xaml
    /// </summary>
    public partial class AddEmail
    {
        #region Private Properties

        private readonly AddEmailWindowViewModel _viewModel;
        private ListMailsViewModel _listMailsViewModel;

        #endregion Private Properties

        #region Constructor

        public AddEmail(ListMailsViewModel listMailsViewModel)
        {
            InitializeComponent();
            _viewModel = new AddEmailWindowViewModel();
            _listMailsViewModel = listMailsViewModel;
            DataContext = _viewModel;
        }

        #endregion Constructor

        #region Event Handlers

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (await _viewModel.SignIn())
            {
                _listMailsViewModel.SetupAfterLogin();
                Close();
            }

            LoginAttemptUnsuccessfulTxtBlock.Visibility = Visibility.Visible;
        }

        #endregion Event Handlers
    }
}