using System;
using System.Collections.Generic;
using SaintSender.Core.Services;
using Spire.Email;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ListMailsViewModel : BaseViewModel
    {
        #region Private Fields

        private List<MailMessage> _messageInfos { get; set; }

        private LoadMessagesService LoadMessagesService { get; set; }

        private string _searchText;

        #endregion Private Fields

        #region Public Fields

        public List<MailMessage> MessageInfos
        {
            get => _messageInfos;
            set
            {
                if (_messageInfos != value)
                {
                    _messageInfos = value;
                }
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                IsSearchBtnEnabled = _searchText.Length >= 3;
                OnPropertyChanged("IsSearchBtnEnabled");
                OnPropertyChanged();
            }
        }

        public bool IsSearchBtnEnabled { get; set; }

        #endregion Public Fields

        #region Constructor

        public ListMailsViewModel()
        {
            LoadMessagesService = new LoadMessagesService();
            _messageInfos = LoadMessagesService.GetMessages();
        }

        #endregion Constructor

        #region Public Methods

        public void Search()
        {
            Console.WriteLine("search");
        }

        #endregion
    }
}