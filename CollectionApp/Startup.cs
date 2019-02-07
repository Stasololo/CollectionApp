using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollectionApp.Startup))]
namespace CollectionApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
