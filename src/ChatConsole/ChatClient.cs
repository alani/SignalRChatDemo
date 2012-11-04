using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SignalR.Client.Hubs;

namespace ChatConsole
{
    public class ChatClient
    {
        static void Main(string[] args)
        {
            // Create connection to hub
            var hubConnection = new HubConnection("http://localhost:1116/");

            // Create hub proxy
            var chatProxy = hubConnection.CreateProxy("chatCentral");

            // On event addMessage, print to Console
            chatProxy.On<string>("addMessage", data => Console.WriteLine(data));

            // Start connection
            hubConnection.Start().Wait();

            // Keep console open and accept user input
            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
                // Send a message to the server
                chatProxy.Invoke("SendMessage", line).Wait();
            }
        }
    }
}
