using System.Windows;
using SaintSender.DesktopUI.Views;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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