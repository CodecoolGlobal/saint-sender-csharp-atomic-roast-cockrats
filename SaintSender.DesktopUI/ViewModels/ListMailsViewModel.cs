﻿using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using Spire.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

        public string SearchResultTxt { get; set; }

        #endregion Public Fields

        #region Constructor

        public ListMailsViewModel()
        {
            try
            {
                _loadMessagesService = new LoadMessagesService();
            }
            catch (Exception exception)
            {
                SearchResultTxt = "Please log in!";
            }
        }

        public async void Setup()
        {
            if (SearchResultTxt != null) return;
            var ts = new CancellationTokenSource();
            Load(ts);
            _messageInfos = await _loadMessagesService.GetMessages();
            _allMessages = _messageInfos;
            ts.Cancel();
            SearchResultTxt = null;
        }

        public async void SetupAfterLogin()
        {
            var ts = new CancellationTokenSource();
            Load(ts);
            _loadMessagesService = new LoadMessagesService();
            _messageInfos = await _loadMessagesService.GetMessages();
            _allMessages = _messageInfos;
            ts.Cancel();
            SearchResultTxt = null;
        }

        #endregion Constructor

        #region Public Methods

        public async void Search()
        {
            MessageInfos = await SearchMails();
            SearchResultTxt = $"We found {MessageInfos.Count} emails. See below:";
            OnPropertyChanged("SearchResultTxt");
        }

        private async Task<List<MailMessage>> SearchMails()
        {
            var messages = new List<MailMessage>();
            return await Task.Run(() =>
            {
                foreach (var message in _allMessages)
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

        public async Task Backup()
        {
            BackUpModel backUpModel = new BackUpModel(MessageInfos);
            if (await backUpModel.Serialize())
            {
                Console.WriteLine("Backup process completed");
                SearchResultTxt = "Backup process completed.";
                OnPropertyChanged("SearchResultTxt");
            }
            else
            {
                Console.WriteLine("Backup process not completed");
                SearchResultTxt = "There was an error during the backup process.";
                OnPropertyChanged("SearchResultTxt");
            }
            OnPropertyChanged("SearchResultTxt");
        }

        #endregion Public Methods

        #region Private Methods

        private void Load(CancellationTokenSource ts)
        {
            CancellationToken ct = ts.Token;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested) break;
                    SearchResultTxt = "Loading...";
                    Thread.Sleep(500);
                    SearchResultTxt = "Please Wait!";
                    Thread.Sleep(500);
                }
            }, ct);
        }

        #endregion Private Methods
    }
}