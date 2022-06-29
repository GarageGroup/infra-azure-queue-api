using System;

namespace GGroupp.Infra;

internal sealed partial class QueueApi : IQueueWriter
{
    public static QueueApi Create(QueueOption option)
        =>
        new(
            option ?? throw new ArgumentNullException(nameof(option)));

    private readonly QueueOption option;

    private QueueApi(QueueOption option)
        =>
        this.option = option;
}