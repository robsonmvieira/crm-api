using crm.Core.Domain.entities;
using crm.Core.Domain.repositories;

namespace crm.Project.Infra.Repositories;

public class Notifier: INotifier
{
    private readonly List<Notification> _notifications = new();
    public bool HasNotification()
    {
        return _notifications.Any();
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public void Handle(Notification notification)
    {
        _notifications.Add(notification);
    }
    
    public int CountNotifications()
    {
        return _notifications.Count;
    }
}