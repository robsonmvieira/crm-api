namespace crm.Project.Domain.repositories;

public interface IProjectService
{
    Task CreateProject(domain.entities.Project project, CancellationToken cancellationToken = default);
    Task BlockProject(Guid projectId, CancellationToken cancellationToken = default);
    Task UnblockProject(Guid projectId, CancellationToken cancellationToken = default);
    
}