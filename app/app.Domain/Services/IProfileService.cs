using app.Domain.Extensions;
using app.Domain.Models.Filters;
using app.Domain.Models;

namespace app.Domain.Services
{
    public interface IProfileService
    {
        /// <summary>
        /// Get all profiles
        /// </summary>
        /// <param name="search">Search criteria/param>
        /// <returns>List of profiles</returns>
        public PagedList<Profile> GetAll(ProfileSearch search);

        /// <summary>
        /// Get profile by name
        /// </summary>
        /// <param name="name">Profile name/param>
        /// <returns>Profile object</returns>
        public Profile GetByName(string name);

        /// <summary>
        /// Get profile by id
        /// </summary>
        /// <param name="id">Profile id/param>
        /// <returns>Profile object</returns>
        public Profile GetById(long id);

        /// <summary>
        /// Add a profile
        /// </summary>
        /// <param name="profile">Profile object/param>
        public Task Add(Profile profile);

        /// <summary>
        /// Update a profile
        /// </summary>
        /// <param name="profile">Profile object/param>
        public Task Update(Profile profile);

        /// <summary>
        /// Delete a profile
        /// </summary>
        /// <param name="id">Profile id/param>
        public void DeleteById(long id);
    }
}