using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SR.Conn
{
    [HubName("MyDataStream")]
    public class MyDataStream : Hub
    {
        [HubMethodName("JoinGroup")]
        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }


        public override Task OnConnected()
        {
            Clients.All.joined(Context.ConnectionId, DateTime.Now.ToString());
            return Clients.All.addMessage("Connection " + Context.ConnectionId + " joined.");
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var groupName = "East";
            Groups.Remove(Context.ConnectionId, groupName);
            groupName = "West";
            return Groups.Remove(Context.ConnectionId, groupName);
        }

        public override Task OnReconnected()
        {
            return Clients.All.rejoined(Context.ConnectionId, DateTime.Now.ToString());
        }

        [HubMethodName("Send")]
        public void Send(string msg)
        {
            Clients.All.addMessage("<b>" + msg + "</b>");
        }

        [HubMethodName("SendIndividual")]
        public void SendIndividual(string msg)
        {
            Clients.Caller.addMessage(msg);
        }

        [HubMethodName("SendGroup")]
        public void SendGroup(string msg, string groupName)
        {
            Clients.Group(groupName).addMessage(msg);
        }

    }
}