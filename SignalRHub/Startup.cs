using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRHub.Startup))]

namespace SignalRHub
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new Microsoft.AspNet.SignalR.HubConfiguration();
            config.EnableJSONP = true;

            app.MapSignalR(config);
        }
    }
}
