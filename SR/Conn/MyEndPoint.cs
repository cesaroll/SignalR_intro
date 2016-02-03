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
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Broadcast("Connection " + connectionId + "<span style='color: blue'> connected.</span>");
        }

        protected override Task OnReconnected(IRequest request, string connectionId)
        {
            return Connection.Broadcast("Connection " + connectionId + "<span style='color: green'> reconnected.</span>");
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            return Connection.Broadcast("Connection " + connectionId + "<span style='color: red'> disconnected.</span>");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            //Broadcast to all awaiting clients (connections)
            return Connection.Broadcast("Data Received " + data + " on connection " + connectionId);
        }
    }
}