using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp.Infra;

public interface IQueueWriter<TMessageJson>
{
    ValueTask<Unit> SendMessageAsync(TMessageJson message, CancellationToken cancellationToken = default);
}