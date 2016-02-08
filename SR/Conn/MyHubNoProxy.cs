using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SR.Conn
{
    [HubName("MyHubNoProxy")]
    public class MyHubNoProxy : Hub
    {
        [HubMethodName("Send")]
        public void Send(string msg)
        {
            // Call addMessage
            Clients.All.addMessage("<span style='color: green'>All: </span>" + msg);
        }
         
    }
}