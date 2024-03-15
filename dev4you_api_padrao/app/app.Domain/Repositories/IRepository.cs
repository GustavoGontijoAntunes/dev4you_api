namespace app.Domain.Repositories
{
    public interface IRepository
    {
        public bool SaveChanges();
        public Task<bool> SaveChangesAsync();
    }
}