using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConscienceLoan.Startup))]
namespace ConscienceLoan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
