﻿using System;
using Spire.Email;

namespace SaintSender.DesktopUI.ViewModels
{
    internal class MailWindowViewModel
    {
        #region Private Properties

        private readonly MailMessage _mail;

        #endregion

        #region Public Properties

        public string FromAddress => _mail.From.Address;

        public string Subject => _mail.Subject;

        public DateTime Date => _mail.Date;

        public string Message => _mail.BodyText;

        #endregion

        #region Constructor

        public MailWindowViewModel(MailMessage mail)
        {
            _mail = mail;
        }

        #endregion
    }
}