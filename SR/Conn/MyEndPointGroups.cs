using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SR.Conn
{
	public class MyEndPointGroups : PersistentConnection
	{
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Groups.Add(connectionId, "MyGroup");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            // group:message

            string[] decoded = data.Split(':');
            string groupName = decoded[0];
            string msg = decoded[1];

            return Groups.Send(groupName, msg);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            return Groups.Remove(connectionId, "MyGroup");
        }

    }
}