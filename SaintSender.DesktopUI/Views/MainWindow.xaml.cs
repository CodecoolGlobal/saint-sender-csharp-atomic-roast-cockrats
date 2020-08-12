using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        #region Private Properties

        private readonly ListMailsViewModel _listMailsViewModel;

        #endregion Private Properties

        public MainWindow()
        {
            InitializeComponent();
            _listMailsViewModel = new ListMailsViewModel();
            DataContext = _listMailsViewModel;
        }

        private void AddEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            Window addEmailWindow = new AddEmail();
            addEmailWindow.ShowDialog();
        }

        private void ComposeEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            Window composeEmailWindow = new ComposeMail();
            composeEmailWindow.ShowDialog();
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindingOperations.GetBindingExpression(SearchTxtBox, TextBox.TextProperty)?.UpdateSource();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            _listMailsViewModel.Search();
        }
    }
}