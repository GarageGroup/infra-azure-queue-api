using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GGroupp.Infra;

internal sealed partial class BusQueueApi<TMessageJson> : IQueueWriter<TMessageJson>
{
    public static BusQueueApi<TMessageJson> Create(ServiceBusQueueOption option)
        =>
        new(
            option ?? throw new ArgumentNullException(nameof(option)));

    private static readonly JsonSerializerOptions jsonSerializerOptions;

    static BusQueueApi()
        =>
        jsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

    private readonly ServiceBusQueueOption option;

    private BusQueueApi(ServiceBusQueueOption option)
        =>
        this.option = option;
}