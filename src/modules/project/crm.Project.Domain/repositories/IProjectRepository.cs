using crm.Core.Domain.repositories;
using ProjectDomain = crm.Project.Domain.domain.entities;

namespace crm.Project.Domain.repositories
{
    public interface IProjectRepository : IRepository<ProjectDomain.Project>
    {
        Task<IEnumerable<ProjectDomain.Project>> GetProjectsByUserId(Guid userId, CancellationToken cancellationToken = default);
        
        // Task AddProject(ProjectDomain.Project project, CancellationToken cancellationToken = default);
        // Task<ProjectDomain.Project> GetProjectById(Guid projectId, CancellationToken cancellationToken = default);
        // Task UpdateProject(ProjectDomain.Project project, CancellationToken cancellationToken = default);
        // Task DeleteProject(ProjectDomain.Project project, CancellationToken cancellationToken = default);
        //
        // Task<IEnumerable<ProjectDomain.Project>> GetProjects(CancellationToken cancellationToken = default);
    }
}