using System.Threading;
using System.Threading.Tasks;

namespace Codelux.NetCore.TaskExecutors
{
    public abstract class TaskExecutorBase<TIn, TOut> : ITaskExecutor<TIn, TOut>
    {
        public async Task<TOut> ExecuteAsync(TIn tin, CancellationToken token = new CancellationToken())
        {
            return await OnExecuteAsync(tin, token).ConfigureAwait(false);
        }
        protected abstract Task<TOut> OnExecuteAsync(TIn tin, CancellationToken token = default(CancellationToken));
    }
}
