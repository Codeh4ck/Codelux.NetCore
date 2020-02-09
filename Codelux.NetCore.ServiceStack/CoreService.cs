using ServiceStack;
using System.Diagnostics;
using System.Reflection;
using Codelux.NetCore.Common.Requests;
using Codelux.NetCore.Common.Responses;

namespace Codelux.NetCore.ServiceStack
{
    public sealed class CoreService : Service
    {
        public VersionResponse Get(VersionRequest request)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            return new VersionResponse()
            {
                Version = versionInfo
            };
        }
    }
}
