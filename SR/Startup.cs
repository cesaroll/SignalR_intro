using Microsoft.Owin;
using Owin;
using SR.Conn;

[assembly: OwinStartupAttribute(typeof(SR.Startup))]
namespace SR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            
            app.MapSignalR<MyEndPoint>("/echo");
            app.MapSignalR<MyEndPoint2>("/echo2");

            app.MapSignalR();


        }
    }
}
