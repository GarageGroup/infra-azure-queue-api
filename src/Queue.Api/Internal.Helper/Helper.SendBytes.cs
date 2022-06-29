using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;

namespace GGroupp.Infra;

partial class QueueApiHelper
{
    internal static async ValueTask<MessageSendOut> SendBytesAsync(byte[] bytes, QueueOption option, CancellationToken cancellationToken)
    {
        var client = new QueueClient(option.QueueConnectionString, option.QueueName);
        var data = new BinaryData(Convert.ToBase64String(bytes));

        var result = await client.SendMessageAsync(data, option.VisibilityTimeout, option.TimeToLive, cancellationToken).ConfigureAwait(false);

        if (result is null)
        {
            return default;
        }

        return new(
            messageId: result.Value.MessageId,
            insertionTime: result.Value.InsertionTime,
            expirationTime: result.Value.ExpirationTime,
            popReceipt: result.Value.PopReceipt,
            timeNextVisible: result.Value.TimeNextVisible);
    }
}