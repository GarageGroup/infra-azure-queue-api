using System;

namespace GGroupp.Infra;

internal sealed partial class BusQueueApi : IQueueWriter
{
    public static BusQueueApi Create(ServiceBusQueueOption option)
        =>
        new(
            option ?? throw new ArgumentNullException(nameof(option)));

    private readonly ServiceBusQueueOption option;

    private BusQueueApi(ServiceBusQueueOption option)
        =>
        this.option = option;
}