using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SR.Conn
{
    public class MyNotifier
    {
        public void Notify(string msg)
        {
            var context = GlobalHost.ConnectionManager.GetConnectionContext<MyEndPoint>();

            context.Connection.Broadcast(msg);

        }

        public void GroupNotify(string group, string msg)
        {
            var context = GlobalHost.ConnectionManager.GetConnectionContext<MyEndPoint>();

            context.Groups.Send(group, msg);
        }

        public void NotifyHub(string msg)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.addMessage(msg);
        }
    }
}