using crm.Core.Domain.repositories;
using crm.Project.Infra.Context;

namespace crm.Project.Infra.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly MyDbContext _context;
    
    public UnitOfWork(MyDbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}