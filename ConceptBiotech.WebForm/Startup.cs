using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConceptBiotech.WebForm.Startup))]
namespace ConceptBiotech.WebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
