using Microsoft.AspNetCore.SignalR;
using SignalRCoreBroadcastSample.Models;
using System.Threading.Tasks;

namespace SignalRCoreBroadcastSample.Hubs
{
    public class MainHub : Hub<IMainHub>
    {
        public async Task Broadcast(Message message)
        {
            await Clients.All.Broadcast(message);
        }
    }
}
