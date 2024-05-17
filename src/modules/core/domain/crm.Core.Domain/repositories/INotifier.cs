using crm.Core.Domain.entities;

namespace crm.Core.Domain.repositories;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
    
}