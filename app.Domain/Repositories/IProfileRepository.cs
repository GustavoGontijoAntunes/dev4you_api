using app.Domain.Extensions;
using app.Domain.Models.Filters;
using app.Domain.Models;
using app.Domain.Models.Authentication;

namespace app.Domain.Repositories
{
    public interface IProfileRepository : IRepository<Profile>
    {
        public PagedList<Profile> GetAll(ProfileSearch search);
        public Profile GetByName(string name);
        public Profile GetById(long id);
        public void DeleteById(long id);
        public bool IsUsedInSomeUser(long id);
    }
}