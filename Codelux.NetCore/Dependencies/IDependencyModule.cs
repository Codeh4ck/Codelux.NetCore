using Unity;

namespace Codelux.NetCore.Dependencies
{
    public interface IDependencyModule
    {
        void OnRegisterDependencies(IUnityContainer unityContainer);
    }
}
