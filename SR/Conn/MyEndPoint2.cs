using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SR.Conn
{
    public class MyEndPoint2 : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            // Sends message to originator only                             
            return Connection.Send(connectionId, "Return to Originator Only: <span style='color: orange'>" + data + "</span>");
        }
    }
}