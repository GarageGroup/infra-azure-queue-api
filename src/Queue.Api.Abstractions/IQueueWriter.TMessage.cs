using System.Threading;
using System.Threading.Tasks;

namespace GGroupp.Infra;

public interface IQueueWriter<TMessageJson>
{
    ValueTask<MessageSendOut> SendMessageAsync(TMessageJson message, CancellationToken cancellationToken = default);
}