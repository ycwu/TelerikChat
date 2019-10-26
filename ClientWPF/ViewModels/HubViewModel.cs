using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace ClientWPF.ViewModels
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
