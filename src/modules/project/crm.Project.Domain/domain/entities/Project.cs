using crm.Project.Domain.domain.enums;
using crm.Core.Domain.entities;
namespace crm.Project.Domain.domain.entities;

public class Project : Entity
{
    public DateTime StartDate { get; private set; }
    public DateTime Deadline { get; private set; }
    public string ProjectName { get; private set; }
    public ProjectStatus Status { get; private set; }
    public ProjectPriority Priority { get; private set; }

    public Guid OwnerId { get; private set; }
    
    public string Description { get; private set; }
    public string? ProjectIcon { get; private set; }
    
    // Parameterless constructor for EF
    protected Project() { }

    public Project(
        string projectName,
        string description,
        DateTime startDate,
        DateTime deadline,
        string ownerId,
        string? id = null,
        DateTime? createdAt = null,
        DateTime? updatedAt = null,
        ProjectPriority priority = ProjectPriority.Low,
        ProjectStatus status = ProjectStatus.Active) :
        base(String.IsNullOrWhiteSpace(id) ? Guid.Empty : Guid.Parse(id), createdAt, updatedAt)
    {
        Status = status;
        Deadline = deadline;
        Priority = priority;
        StartDate = startDate;
        ProjectName = projectName;
        Description = description;
        OwnerId = Guid.Parse(ownerId);
    }

    public static Project Create(string projectName,
        string description,
        DateTime startDate,
        DateTime deadline,
        string ownerId,
        ProjectPriority priority = ProjectPriority.Low,
        ProjectStatus status = ProjectStatus.Active)
    {
        return new Project(
            projectName,
            description,
            startDate: startDate,
            deadline: deadline,
            priority: priority,
            status: status,
            ownerId: ownerId
            );
    }
    
    public void Block()
    {
        Status = ProjectStatus.Blocked;
    }
    
    public void Unblock()
    {
        Status = ProjectStatus.Active;
    }
}


