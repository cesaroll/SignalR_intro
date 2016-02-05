using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SR.Conn
{
    [HubName("MyHubGroups")]
    public class MyHubGroups : Hub
    {
        public override Task OnConnected()
        {
            // Specific to the connection
            this.Clients.Caller.addMessage("<span style='color: blue'>Connected: </span>" + Context.ConnectionId);

            return base.OnConnected();
        }

        [HubMethodName("JoinGroup")]
        public Task JoinGroup(string groupName)
        {
            this.Clients.Caller.addMessage("<span style='color: green'>Joinning group: </span>" + groupName);
            return Groups.Add(Context.ConnectionId, groupName);
        }
        
        [HubMethodName("LeaveGroup")]
        public Task LeaveGroup(string groupName)
        {
            this.Clients.Caller.addMessage("<span style='color: orange'>Leaving group: </span>" + groupName);
            return Groups.Remove(Context.ConnectionId, groupName);
        }
        
        [HubMethodName("Send")]
        public Task Send(string groupName, string msg)
        {
            return Clients.Group(groupName).addMessage("<span style='color: green'>" + groupName + ": </span>" + msg);
        }
        
        
        
    }
}