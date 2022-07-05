using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace GGroupp.Infra;

partial class BusQueueApiHelper
{
    internal static ValueTask<Unit> SendBytesAsync(ReadOnlyMemory<byte> bytes, ServiceBusQueueOption option, CancellationToken cancellationToken)
    {
        var client = new ServiceBusClient(option.ConnectionString);
        var sender = client.CreateSender(option.Name);

        var message = new ServiceBusMessage(bytes);
        return Unit.InvokeAsync(sender.SendMessageAsync, message, cancellationToken).ToValueTask();
    }

    private static ValueTask<Unit> ToValueTask(this Task<Unit> task)
        =>
        new(task);
}