namespace crm.Core.Domain.entities;

public class Notification(string message)
{
    public string? Message { get; } = message;
}