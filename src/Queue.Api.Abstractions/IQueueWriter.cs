using System.Threading;
using System.Threading.Tasks;

namespace GGroupp.Infra;

public interface IQueueWriter
{
    ValueTask<MessageSendOut> SendMessageAsync(string message, CancellationToken cancellationToken = default);
}