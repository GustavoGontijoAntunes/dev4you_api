using app.Domain.Extensions;
using app.Domain.Models.Authentication;
using app.Domain.Models.Filters;

namespace app.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public bool Login(string login, string password);
        public PagedList<User> GetAll(UserSearch search);
        public User GetByLogin(string login);
        public User GetById(long id);
        public void DeleteById(long id);
    }
}