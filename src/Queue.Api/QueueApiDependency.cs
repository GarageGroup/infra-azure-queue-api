using System;
using PrimeFuncPack;

namespace GGroupp.Infra;

public static class QueueApiDependency
{
    public static Dependency<IQueueWriter> UseQueueWriter(this Dependency<QueueOption> dependency)
    {
        _ = dependency ?? throw new ArgumentNullException(nameof(dependency));

        return dependency.Map<IQueueWriter>(QueueApi.Create);
    }

    public static Dependency<IQueueWriter<TMessageJson>> UseQueueWriter<TMessageJson>(this Dependency<QueueOption> dependency)
    {
        _ = dependency ?? throw new ArgumentNullException(nameof(dependency));

        return dependency.Map<IQueueWriter<TMessageJson>>(QueueApi<TMessageJson>.Create);
    }
}