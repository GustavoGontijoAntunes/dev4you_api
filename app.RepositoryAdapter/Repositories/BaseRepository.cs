using Microsoft.EntityFrameworkCore;
using app.Domain.Repositories;
using app.Domain.Models.Base;

namespace app.RepositoryAdapter.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        private readonly AppDbContext _context;
        protected DbSet<TEntity> Repository;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            Repository = context.Set<TEntity>();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            Repository.Add(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;

            Repository.Update(entity);
            return await SaveChangesAsync();
        }

    }
}