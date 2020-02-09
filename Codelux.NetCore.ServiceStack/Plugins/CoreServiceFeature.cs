using ServiceStack;
using Codelux.NetCore.Common.Requests;

namespace Codelux.NetCore.ServiceStack.Plugins
{
    public class CoreServiceFeature : IPlugin
    {
        public void Register(IAppHost appHost)
        {
            appHost.Routes.Add<VersionRequest>("/api/version", "Get");
            appHost.RegisterService<CoreService>();
        }
    }
}
