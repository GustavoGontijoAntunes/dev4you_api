using app.Domain.Models.Base;

namespace app.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        public bool SaveChanges();
        public Task<bool> SaveChangesAsync();
        public Task<bool> Add(TEntity entity);
        public Task<bool> Update(TEntity entity);
    }
}