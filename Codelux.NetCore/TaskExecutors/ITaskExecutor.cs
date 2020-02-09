using System.Threading;
using System.Threading.Tasks;

namespace Codelux.NetCore.TaskExecutors
{
    public interface ITaskExecutor<in TIn, TOut>
    {
        Task<TOut> ExecuteAsync(TIn tin, CancellationToken token = default(CancellationToken));
    }
}
