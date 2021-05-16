using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace SignalRDemo.Hubs
{
    [HubName("NotificationHub")]
    public class NotificationHub : Hub
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationHub(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessage(string user, string message)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:50735/apiHub")
                .Build();
            connection.StartAsync().Wait();

            await connection.InvokeAsync("SendMessage", "sadsd", "sdf");

            connection.On<string, string>("ReceiveMessage", (user1, message1) =>
            {
                _hubContext.Clients.All.SendAsync("ReceiveMessage", user1, message1);
            });
        }
    }
}
    }
}