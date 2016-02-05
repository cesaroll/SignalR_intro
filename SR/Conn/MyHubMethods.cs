using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SR.Conn
{
    [HubName("MyHubMethods")]
    public class MyHubMethods : Hub
    {
        [HubMethodName("Send")]
        public void Send(string msg)
        {
            // Call addMessage
            Clients.All.addMessage("<span style='color: green'>All: </span>" + msg);

            // Specific to the connection
            this.Clients.Caller.addMessage("<span style='color: blue'>Caller: </span>" + msg);

        }
    }
}