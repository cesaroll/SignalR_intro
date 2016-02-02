using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SR.Conn
{
    public class MyEndPoint : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            //Broadcast to all awaiting clients (connections)
            return Connection.Broadcast("Data Received " + data + " on connection " + connectionId);
        }
    }
}