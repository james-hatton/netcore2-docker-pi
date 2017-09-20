using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebApplication5.Hubs
{
    public class MessageHub : Hub
    {
        public MessageHub()
        {
        }
        public override Task OnConnectedAsync()
        {

            return base.OnConnectedAsync();
        }
    }
}
