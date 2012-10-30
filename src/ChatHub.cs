using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChatDemo
{
    [HubName("chatCentral")]
    public class ChatHub : Hub
    {
        public void NotifyClients()
        {
            Caller.notifyCaller("From Server:  You broadcasted to clients!");
            Clients.broadcast("From Server: Ping initiated by" + Context.ConnectionId);
        }

        public void SendMessage(string msg)
        {
            Clients.addMessage(string.Format("{0}:\t{1}", Context.ConnectionId, msg));
        }
    }
}