using app.Domain.Extensions;
using app.Domain.Models.Authentication;
using app.Domain.Models.Filters;

namespace app.Domain.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Validate User in app
        /// </summary>
        /// <param name="user">User object/param>
        /// <returns>Task request about user authentication</returns>
        public Task<UserAuthenticated> Login(User user);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="search">Search criteria/param>
        /// <returns>List of users</returns>
        public PagedList<User> GetAll(UserSearch search);

        /// <summary>
        /// Get user by login
        /// </summary>
        /// <param name="login">User login/param>
        /// <returns>User object</returns>
        public User GetByLogin(string login);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id/param>
        /// <returns>User object</returns>
        public User GetById(long id);

        /// <summary>
        /// Add an user
        /// </summary>
        /// <param name="user">User object/param>
        public Task Add(User user);

        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="user">User object/param>
        public Task Update(User user);

        /// <summary>
        /// Change password of the user in app
        /// </summary>
        /// <param name="id">User id/param>
        /// <param name="user">User object/param>
        public Task ChangePassword(long id, User user);

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="id">User id/param>
        public void DeleteById(long id);
    }
}