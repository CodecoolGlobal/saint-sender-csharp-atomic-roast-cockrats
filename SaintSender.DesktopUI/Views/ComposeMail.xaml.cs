using System.Windows;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ComposeMail.xaml
    /// </summary>
    public partial class ComposeMail
    {
        #region Private Properties

        private readonly ComposeMailViewModel _composeMailViewModel;

        #endregion Private Properties

        #region Constructor

        public ComposeMail()
        {
            InitializeComponent();
            _composeMailViewModel = new ComposeMailViewModel();
            DataContext = _composeMailViewModel;
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
            await _composeMailViewModel.Compose();
        }

        #endregion Event Handlers
    }
}