using System;
using PrimeFuncPack;

namespace GGroupp.Infra;

public static class ServiceBusQueueApiDependency
{
    public static Dependency<IQueueWriter> UseServiceBusQueueWriter(this Dependency<ServiceBusQueueOption> dependency)
    {
        _ = dependency ?? throw new ArgumentNullException(nameof(dependency));

        return dependency.Map<IQueueWriter>(BusQueueApi.Create);
    }

    public static Dependency<IQueueWriter<TMessageJson>> UseServiceBusQueueWriter<TMessageJson>(this Dependency<ServiceBusQueueOption> dependency)
    {
        _ = dependency ?? throw new ArgumentNullException(nameof(dependency));

        return dependency.Map<IQueueWriter<TMessageJson>>(BusQueueApi<TMessageJson>.Create);
    }
}