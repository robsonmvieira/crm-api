using crm.Core.Domain.entities;
using crm.Core.Domain.repositories;
using crm.Project.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace crm.Project.Infra.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly MyDbContext _context;
    private  DbSet<TEntity> DbSet => _context.Set<TEntity>();
    
    
    public Repository(MyDbContext context)
    {
        _context = context;
    }
    public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public async Task Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityToDelete = await DbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

        if (entityToDelete != null)
            DbSet.Remove(entityToDelete);
    }

    public async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => 
            x.Id.Equals(id), cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default)
    {
       return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

 

    public void Dispose()
    {
        _context?.Dispose();
    }
}