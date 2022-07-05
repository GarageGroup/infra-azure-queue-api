namespace GGroupp.Infra;

public sealed record class ServiceBusQueueOption
{
    public ServiceBusQueueOption(string connectionString, string name)
    {
        ConnectionString = connectionString ?? string.Empty;
        Name = name ?? string.Empty;
    }

    public string ConnectionString { get; }

    public string Name { get; }
}