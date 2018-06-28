using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaNutricionista.Startup))]
namespace SistemaNutricionista
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
