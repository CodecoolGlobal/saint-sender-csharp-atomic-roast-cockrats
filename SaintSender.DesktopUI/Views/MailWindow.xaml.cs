using SaintSender.DesktopUI.ViewModels;
using Spire.Email;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MailWindow.xaml
    /// </summary>
    public partial class MailWindow
    {
        #region Constructor

        public MailWindow(MailMessage mail)
        {
            InitializeComponent();
            DataContext = new MailWindowViewModel(mail);
        }

        #endregion Constructor
    }
}