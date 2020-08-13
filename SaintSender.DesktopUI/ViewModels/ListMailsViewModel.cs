using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SaintSender.Core.Services;
using Spire.Email;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ListMailsViewModel : BaseViewModel
    {
        #region Private Fields

        private List<MailMessage> _messageInfos { get; set; }

        private List<MailMessage> _allMessages { get; set; }

        private LoadMessagesService _loadMessagesService { get; set; }

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
            _loadMessagesService = new LoadMessagesService();
        }

        public async void Setup()
        {
            _messageInfos = await _loadMessagesService.GetMessages();
            _allMessages = _messageInfos;
        }

        #endregion Constructor

        #region Public Methods

        public async void Search()
        {
            MessageInfos = await SearchMails();
            Console.WriteLine(_allMessages.Count);
        }

        private async Task<List<MailMessage>> SearchMails()
        {
            var messages = new List<MailMessage>();
            return await Task.Run(() =>
            {
                foreach (var message in MessageInfos)
                {
                    if (Regex.IsMatch(message.Subject, SearchText) ||
                        Regex.IsMatch(message.BodyText, SearchText))
                    {
                        messages.Add(message);
                        continue;
                    }

                    messages.AddRange(from mailAddress in message.To
                        where Regex.IsMatch(mailAddress.Address, SearchText)
                        select message);
                }

                return messages;
            });
        }

        #endregion
    }
}