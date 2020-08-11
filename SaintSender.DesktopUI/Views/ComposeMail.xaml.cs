using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ComposeMail.xaml
    /// </summary>
    public partial class ComposeMail : Window
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
            Close();
        }

        private void ComposeButton_Click(object sender, RoutedEventArgs e)
        {
            _composeMailViewModel.Compose();
        }

        #endregion Event Handlers
    }
}