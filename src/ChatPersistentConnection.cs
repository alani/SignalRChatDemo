using System.Threading.Tasks;
using SignalR;

namespace SignalRChatDemo
{
    public class ChatPersistentConnection : PersistentConnection
    {
        protected override Task OnConnectedAsync(IRequest request, string connectionId)
        {
            Connection.Broadcast("Connection " + connectionId + " connected");

            return base.OnConnectedAsync(request, connectionId);
        }

        protected override Task OnReceivedAsync(IRequest request, string connectionId, string data)
        {
            Connection.Broadcast("Connection" + connectionId + ":\t" + data);

            return base.OnReceivedAsync(request, connectionId, data);
        }
    }
}