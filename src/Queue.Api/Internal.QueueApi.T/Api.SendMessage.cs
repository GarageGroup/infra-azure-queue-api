using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp.Infra;

partial class QueueApi<TMessageJson>
{
    public ValueTask<Unit> SendMessageAsync(TMessageJson message, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ValueTask.FromCanceled<Unit>(cancellationToken);
        }

        var bytes = JsonSerializer.SerializeToUtf8Bytes(message, jsonSerializerOptions);
        return QueueApiHelper.SendBytesAsync(bytes, option, cancellationToken);
    }
}