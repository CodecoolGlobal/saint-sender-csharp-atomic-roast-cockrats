using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for DisposeMailWindow.xaml
    /// </summary>
    public partial class DisposeMailWindow
    {
        #region Constructor

        public DisposeMailWindow()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Event Handlers

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            for (int i = 0; i < Application.Current.Windows.Count; i++)
            {
                if (Application.Current.Windows[i]?.Name == "ComposeWindow")
                {
                    Application.Current.Windows[i].Close();
                }
            }
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion Event Handlers
    }
}