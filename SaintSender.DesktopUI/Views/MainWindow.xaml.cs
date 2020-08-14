using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views;
using Spire.Email;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            _listMailsViewModel = new ListMailsViewModel();
            DataContext = _listMailsViewModel;
            _listMailsViewModel.Setup();
        }

        #endregion

        #region Evenet Handlers

        private void AddEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            Window addEmailWindow = new AddEmail(_listMailsViewModel);
            addEmailWindow.ShowDialog();
        }

        private void ComposeEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            Window composeEmailWindow = new ComposeMail(_listMailsViewModel);
            composeEmailWindow.ShowDialog();
        }

        private void MailDataGridRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var mail = (MailMessage) MailDataGrid.SelectedItem;
            Window mailWindow = new MailWindow(mail);
            mailWindow.ShowDialog();
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindingOperations.GetBindingExpression(SearchTxtBox, TextBox.TextProperty)?.UpdateSource();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            _listMailsViewModel.Search();
        }

        private async void BackUpBtn_Click(object sender, RoutedEventArgs e)
        {
            await _listMailsViewModel.Backup();
        }

        #endregion
    }
}