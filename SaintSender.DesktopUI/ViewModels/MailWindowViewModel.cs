﻿using Spire.Email;
using System;

namespace SaintSender.DesktopUI.ViewModels
{
    internal class MailWindowViewModel
    {
        #region Private Fields

        private readonly MailMessage _mail;

        #endregion Private Fields

        #region Public Fields

        public string FromAddress => _mail.From.Address;

        public string Subject => _mail.Subject;

        public DateTime Date => _mail.Date;

        public string Message => _mail.BodyText;

        #endregion Public Fields

        #region Constructor

        public MailWindowViewModel(MailMessage mail)
        {
            _mail = mail;
        }

        #endregion Constructor
    }
}