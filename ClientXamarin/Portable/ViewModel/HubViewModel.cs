using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientXamarin.Portable.ViewModel
{
    public class HubViewModel : ViewModelBase
    {
        protected IHubProxy Proxy { get; set; }

        protected string url = "https://localhost:44337/";

        protected HubConnection Connection { get; set; }

        public HubViewModel()
        {
            {
                this.Connection = new HubConnection(url);

                this.Proxy = Connection.CreateHubProxy("SampleHub");

                this.Connection.Start().Wait();

            }
        }
    }
}
