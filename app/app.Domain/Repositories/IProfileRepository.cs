using app.Domain.Extensions;
using app.Domain.Models.Filters;
using app.Domain.Models;

namespace app.Domain.Repositories
{
    public interface IProfileRepository : IRepository
    {
        public PagedList<Profile> GetAll(ProfileSearch search);
        public Profile GetByName(string name);
        public Profile GetById(long id);
        public Task Add(Profile profile);
        public Task Update(Profile profile);
        public void DeleteById(long id);
        public bool IsUsedInSomeUser(long id);
    }
}