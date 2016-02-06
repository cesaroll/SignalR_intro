using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SR.Conn
{
    public class Product
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    [HubName("MyHubTypes")]
    public class MyHubTypes : Hub
    {
        [HubMethodName("Send")]
        public Product Send(string data)
        {
            return new Product { Name = "Pepsi", CategoryId = 1 };
        }
    }
}