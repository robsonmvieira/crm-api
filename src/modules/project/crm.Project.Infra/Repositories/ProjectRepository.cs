using crm.Project.Domain.repositories;
using DomainEntities = crm.Project.Domain.domain.entities;
using crm.Project.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace crm.Project.Infra.Repositories
{
    public class ProjectRepository : Repository<DomainEntities.Project>, IProjectRepository
    {
        private readonly MyDbContext _context;
        
        public ProjectRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DomainEntities.Project>> GetProjectsByUserId(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Projects.AsNoTracking().Where(x => x.OwnerId.Equals(userId)).ToListAsync(cancellationToken);
        }
    }
}