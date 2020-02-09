using System.Threading;
using System.Threading.Tasks;
using Codelux.NetCore.TaskExecutors;
using NUnit.Framework;

namespace Codelux.NetCore.Tests.TaskExecutors
{
    [TestFixture]
    public class TaskExecutorTests
    {
        private TaskExecutorBase<TestExecutorInputModel, TestExecutorOutputModel> _executor;

        [SetUp]
        public void Setup()
        {
            _executor = new TestExecutor();
        }

        [Test]
        public async Task GivenTaskExecutorWhenIExecuteThenExecutorExecutesAndResultIsCorrect()
        {
            TestExecutorInputModel input = new TestExecutorInputModel()
            {
                GreaterThanZero = false
            };

            TestExecutorOutputModel model = await _executor.ExecuteAsync(input).ConfigureAwait(false);

            Assert.IsNotNull(model);
            Assert.AreEqual(-10, model.Value);
        }
    }


    class TestExecutor : TaskExecutorBase<TestExecutorInputModel, TestExecutorOutputModel>
    {
        protected override Task<TestExecutorOutputModel> OnExecuteAsync(TestExecutorInputModel tin, CancellationToken token = default(CancellationToken))
        {
            if (tin.GreaterThanZero)
                return Task.FromResult(new TestExecutorOutputModel() {Value = 10});

            return Task.FromResult(new TestExecutorOutputModel() { Value = -10 });
        }
    }
}
