using System.Windows;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for AddEmail.xaml
    /// </summary>
    public partial class AddEmail
    {
        #region Private Properties

        private readonly AddEmailWindowViewModel _viewModel;

        #endregion

        #region Constructor

        public AddEmail()
        {
            InitializeComponent();
            _viewModel = new AddEmailWindowViewModel();
            DataContext = _viewModel;
        }

        #endregion

        #region Event Handlers

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SignIn();
        }

        #endregion
    }
}