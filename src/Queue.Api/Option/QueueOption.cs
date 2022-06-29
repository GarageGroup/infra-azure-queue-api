using System;

namespace GGroupp.Infra;

public sealed record class QueueOption
{
    public QueueOption(string queueConnectionString, string queueName, TimeSpan? visibilityTimeout, TimeSpan? timeToLive)
    {
        QueueConnectionString = queueConnectionString ?? string.Empty;
        QueueName = queueName ?? string.Empty;
        VisibilityTimeout = visibilityTimeout;
        TimeToLive = timeToLive;
    }

    public string QueueConnectionString { get; }

    public string QueueName { get; }

    public TimeSpan? VisibilityTimeout { get; }

    public TimeSpan? TimeToLive { get; }
}