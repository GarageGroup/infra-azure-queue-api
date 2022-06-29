using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GGroupp.Infra;

internal sealed partial class QueueApi<TMessageJson> : IQueueWriter<TMessageJson>
{
    public static QueueApi<TMessageJson> Create(QueueOption option)
        =>
        new(
            option ?? throw new ArgumentNullException(nameof(option)));

    private static readonly JsonSerializerOptions jsonSerializerOptions;

    static QueueApi()
        =>
        jsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

    private readonly QueueOption option;

    private QueueApi(QueueOption option)
        =>
        this.option = option;
}