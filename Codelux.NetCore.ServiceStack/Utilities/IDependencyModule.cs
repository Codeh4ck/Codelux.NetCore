using System;
using ServiceStack;

namespace Codelux.NetCore.ServiceStack.Utilities
{
    public interface IDependencyModule : IDisposable
    {
        ServiceStackHost AppHost { get; }
        void RegisterDependencies();
    }
}
