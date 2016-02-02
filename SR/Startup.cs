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

            //app.MapConnection<MyEndPoint>("echo/{*operation}");
            app.MapSignalR<MyEndPoint>("/echo");

        }
    }
}
