﻿using System;

namespace SaintSender.Core.Entities
{
    [Serializable]
    public class MailModel
    {
        public string From;
        public string To;
        public DateTime Date;
        public string Subject;
        public string Body;

        public MailModel(string from, string to, DateTime date, string subject, string body)
        {
            From = from;
            To = to;
            Date = date;
            Subject = subject;
            Body = body;
        }
    }
}