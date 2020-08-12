using System.Windows;
using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views;

// ReSharper disable once CheckNamespace
namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var listMailsViewModel = new ListMailsViewModel();
            DataContext = listMailsViewModel;
            listMailsViewModel.Setup();
        }

        private void AddEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            Window addEmailWindow = new AddEmail();
            addEmailWindow.ShowDialog();
        }

        private void ComposeEmail_Click(object sender, RoutedEventArgs e)
        {
            Window composeEmailWindow = new ComposeMail();
            composeEmailWindow.ShowDialog();
        }
    }
}