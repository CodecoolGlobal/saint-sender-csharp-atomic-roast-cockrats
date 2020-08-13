using SaintSender.DesktopUI.ViewModels;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ComposeMail.xaml
    /// </summary>
    public partial class ComposeMail
    {
        #region Private Properties

        private readonly ComposeMailViewModel _composeMailViewModel;

        private ListMailsViewModel _listMailsViewModel;

        #endregion Private Properties

        #region Constructor

        public ComposeMail(ListMailsViewModel listMailsViewModel)
        {
            InitializeComponent();
            _composeMailViewModel = new ComposeMailViewModel();
            DataContext = _composeMailViewModel;
            _listMailsViewModel = listMailsViewModel;
        }

        #endregion Constructor

        #region Event Handlers

        private void ComposeWindowCancel_Click(object sender, RoutedEventArgs e)
        {
            Window warningWindow = new DisposeMailWindow();
            warningWindow.ShowDialog();
        }

        private async void ComposeButton_Click(object sender, RoutedEventArgs e)
        {
            if (await _composeMailViewModel.Compose())
            {
                _listMailsViewModel.SearchResultTxt = "Email sent successfully.";
                Close();
            }
        }

        #endregion Event Handlers
    }
}