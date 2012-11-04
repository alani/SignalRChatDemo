using SignalR.Hubs;

namespace SignalRChatDemo
{
    public class DrawHub : Hub
    {
        public void mouseMoving(DrawMessage message)
        {
            Clients.mouseMoved(Context.ConnectionId, message);
        }
    }

    // drawHub.mouseMoving({ xcoord: e.pageX, ycoord: e.pageY, drawing: true });

    public class DrawMessage
    {
        public double xcoord { get; set; }
        public double ycoord { get; set; }
        public bool drawingNow { get; set; }
    }
}