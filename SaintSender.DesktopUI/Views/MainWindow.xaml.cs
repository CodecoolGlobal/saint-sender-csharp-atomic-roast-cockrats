using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views;
using Spire.Email;

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

        private void MailDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                DataGridRow dataGridRow = (DataGridRow) sender;
                Console.WriteLine("Success");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void MailDataGridRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var mail = (MailMessage) MailDataGrid.SelectedItem;
            Window mailWindow = new MailWindow(mail);
            mailWindow.ShowDialog();
        }
    }
}