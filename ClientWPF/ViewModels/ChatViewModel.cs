﻿using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls.ConversationalUI;

namespace ClientWPF.ViewModels
{
    public class ChatViewModel : HubViewModel
    {
        private TextMessage currentMessage;
        public TextMessage CurrentMessage
        {
            get { return currentMessage; }
            set
            {
                if (value != null || value != currentMessage)
                {
                    currentMessage = value;
                    OnPropertyChanged("CurrentMessage");
                }
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                if (value != null || value != userName)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        private Author currentAuthor;
        public Author CurrentAuthor
        {
            get { return currentAuthor; }
            set
            {
                if (value != null || value != currentAuthor)
                {
                    currentAuthor = value;
                    OnPropertyChanged("CurrentAuthor");
                }
            }
        }

        private ObservableCollection<TextMessage> allMessages;
        public ObservableCollection<TextMessage> AllMessages
        {
            get { return allMessages; }
            set
            {
                if (value != null || value != allMessages)
                {
                    allMessages = value;
                    OnPropertyChanged("AllMessages");
                }
            }
        }

        public ChatViewModel(string userName)
        {
            this.UserName = userName;
            this.CurrentAuthor = new Author(this.UserName);

            this.AllMessages = new ObservableCollection<TextMessage>();

            // Invokes the Register method on the server
            this.Proxy.Invoke("Register", this.UserName);

            // Subscribes to the broadcastMessage method on the server.
            // The OnBroadCastMessage method will be raised everytime the Send method on the server is invoked.
            this.Proxy.On("broadcastMessage", (string from, string message) => this.OnBroadCastMessage(from, message));
        }

        internal void OnBroadCastMessage(string from, string message)
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                this.AllMessages.Add(new TextMessage(new Author(from), message));
            }));
        }

        internal void SendCurrentMessage()
        {
            if (!string.IsNullOrEmpty((this.CurrentMessage as TextMessage).Text))
            {
                // Invokes the Send method on the server, which in turn invokes the broadcastMessage of all clients.
                this.Proxy.Invoke("Send", this.UserName, this.CurrentMessage.Text);
            }
        }
    }
}
