using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SR.Conn
{
    [HubName("MyHub")]
    public class MyHub : Hub
    {
        [HubMethodName("Send")]
        public void Send(string message)
        {
            // Call addMessage
            Clients.All.addMessage(message);
        }
    }
}