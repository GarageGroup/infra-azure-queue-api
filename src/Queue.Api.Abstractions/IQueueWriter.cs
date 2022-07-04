using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp.Infra;

public interface IQueueWriter
{
    ValueTask<Unit> SendMessageAsync(string message, CancellationToken cancellationToken = default);
}