using SignalRCoreBroadcastSample.Models;
using System.Threading.Tasks;

namespace SignalRCoreBroadcastSample.Hubs
{
    public interface IMainHub
    {
        Task Broadcast(Message message);
    }
}
