using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;

namespace BRMSWebApp.Hubs
{
    public class NotificationHelper
    {
        public void NotificationCaller(string msg1, string msg2)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.SendAsync("sendToUser", "ssssssssss", "aaaaaaaaaaaaa");
        }
    }
}
