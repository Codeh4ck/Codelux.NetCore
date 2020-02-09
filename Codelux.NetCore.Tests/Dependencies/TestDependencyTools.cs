using Unity;
using Codelux.NetCore.Dependencies;

namespace Codelux.NetCore.Tests.Dependencies
{
    public class TestDependencyModule : DependencyModule
    {
        public TestDependencyModule(IUnityContainer container) : base(container) { }
        public override void OnRegisterDependencies(IUnityContainer container)
        {
            ITestInterface toRegister = new TestConcreteClass();
            container.RegisterInstance<ITestInterface>(toRegister);
        }
    }

    public interface ITestInterface
    {
        int GetOne();
    }

    public class TestConcreteClass : ITestInterface
    {
        public int GetOne()
        {
            return 1;
        }
    }
}
