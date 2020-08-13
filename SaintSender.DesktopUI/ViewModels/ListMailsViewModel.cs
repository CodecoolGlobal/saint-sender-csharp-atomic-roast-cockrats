using System;
using System.Collections.Generic;
using System.Linq;
using SaintSender.Core.Services;
using Spire.Email;
using Spire.Email.Pop3;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ListMailsViewModel : BaseViewModel
    {
        #region Private Fields

        private List<MailMessage> _messageInfos { get; set; }

        private LoadMessagesService LoadMessagesService { get; set; }

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

        #endregion Public Fields

        #region Constructor

        public ListMailsViewModel()
        {
            LoadMessagesService = new LoadMessagesService();
        }

        public async void Setup()
        {
            _messageInfos = await LoadMessagesService.GetMessages();
        }

        #endregion Constructor
    }
}