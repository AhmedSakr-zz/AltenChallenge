using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHub.Hubs
{
    public interface IEventHub
    {
        // here place some method(s) for message from server to client
        Task SendNoticeEventToClient(string message);
    }

    public class EventHub : Hub<IEventHub>
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendNoticeEventToClient(message);
        }

    }
}