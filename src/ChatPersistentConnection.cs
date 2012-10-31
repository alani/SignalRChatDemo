using System.Threading.Tasks;
using SignalR;
using Newtonsoft.Json;

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
            var message = JsonConvert.DeserializeObject<ChatMessage>(data);

            switch(message.Type)
            {
                case MessageType.Standard:
                    Connection.Broadcast("Connection " + connectionId + ":\t" + message.Data);
                    break;
                case MessageType.Broadcast:
                    Connection.Broadcast("From SERVER:  Ping Initiated by " + connectionId);
                    break;
            }

            return base.OnReceivedAsync(request, connectionId, data);
        }
    }

    public enum MessageType
    {
        Standard,
        Broadcast
    }

    public class ChatMessage
    {
        public MessageType Type { get; set; }
        public string Data { get; set; }
    }
}