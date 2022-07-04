using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;

namespace GGroupp.Infra;

partial class QueueApiHelper
{
    internal static async ValueTask<Unit> SendBytesAsync(byte[] bytes, QueueOption option, CancellationToken cancellationToken)
    {
        var client = new QueueClient(option.QueueConnectionString, option.QueueName);
        var data = new BinaryData(Convert.ToBase64String(bytes));

        var result = await client.SendMessageAsync(data, option.VisibilityTimeout, option.TimeToLive, cancellationToken).ConfigureAwait(false);
        return Unit.From(result);
    }
}