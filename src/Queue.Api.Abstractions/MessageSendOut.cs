using System;
using System.Diagnostics.CodeAnalysis;

namespace GGroupp.Infra;

public readonly record struct MessageSendOut
{
    private readonly string? messageId;

    private readonly string? popReceipt;

    public MessageSendOut(
        [AllowNull] string messageId,
        DateTimeOffset insertionTime,
        DateTimeOffset expirationTime,
        [AllowNull] string popReceipt,
        DateTimeOffset timeNextVisible)
    {
        this.messageId = string.IsNullOrEmpty(messageId) ? null : messageId;
        this.popReceipt = string.IsNullOrEmpty(popReceipt) ? null : popReceipt;
        InsertionTime = insertionTime;
        ExpirationTime = expirationTime;
        TimeNextVisible = timeNextVisible;
    }

    public string MessageId => messageId ?? string.Empty;

    public DateTimeOffset InsertionTime { get; }

    public DateTimeOffset ExpirationTime { get; }

    public string PopReceipt => popReceipt ?? string.Empty;

    public DateTimeOffset TimeNextVisible { get; }
}