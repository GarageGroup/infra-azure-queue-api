using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp.Infra;

partial class QueueApi
{
    public ValueTask<MessageSendOut> SendMessageAsync(string message, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ValueTask.FromCanceled<MessageSendOut>(cancellationToken);
        }

        var bytes = Encoding.UTF8.GetBytes(message);
        return QueueApiHelper.SendBytesAsync(bytes, option, cancellationToken);
    }
}