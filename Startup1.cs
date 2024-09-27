using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Unommer;
using Unommer.Chat_Unommer;

[assembly: OwinStartup(typeof(Unommer.Startup1))]

namespace Unommer
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            //app.MapSignalR();
        }
    }
}
