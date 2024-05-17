using crm.Core.Domain.entities;
using crm.Core.Domain.repositories;
using crm.Project.Domain.domain.validations;
using crm.Project.Domain.repositories;
using crm.Project.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace crm.Project.Infra.Repositories;

public class ProjectService: BaseService, IProjectService
{
    
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _uow;
    public ProjectService(IProjectRepository projectRepository, IUnitOfWork uow, INotifier notifier) : base(notifier)
    {
      
        _projectRepository = projectRepository;
        _uow = uow;
    }

    public async Task CreateProject(Domain.domain.entities.Project project, CancellationToken cancellationToken = default)
    {
        if (!ValidateExecution(project, new ProjectValidator()))
        {
            Notify("Invalid project");
            return;
        }
        
        await _projectRepository.Add(project, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
    }

    public async Task BlockProject(Guid projectId, CancellationToken cancellationToken = default)
    {
        var project = await _projectRepository.GetById(projectId, cancellationToken);
        if (project != null)
        {
            project.Block();
            await _projectRepository.Update(project, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task UnblockProject(Guid projectId, CancellationToken cancellationToken = default)
    {
        Domain.domain.entities.Project? project = await _projectRepository.GetById(projectId, cancellationToken);

        if (project == null)
        {
            Notify("Project not found");
            return;
        }
        project.Unblock();
        await _projectRepository.Update(project, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        
    }
}