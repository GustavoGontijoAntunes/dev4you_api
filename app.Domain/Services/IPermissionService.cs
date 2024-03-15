using app.Domain.Models;
using app.Domain.Models.Excel;
using Microsoft.AspNetCore.Http;

namespace app.Domain.Services
{
    public interface IPermissionService
    {
        /// <summary>
        /// Get all permissions
        /// </summary>
        /// <returns>List of permissions</returns>
        public IEnumerable<Permission> GetAll();

        /// <summary>
        /// Get permission by name
        /// </summary>
        /// <param name="name">Permission name/param>
        /// <returns>Permission object</returns>
        public Permission GetByName(string name);

        /// <summary>
        /// Get permission by id
        /// </summary>
        /// <param name="id">Permission id/param>
        /// <returns>Permission object</returns>
        public Permission GetById(long id);

        /// <summary>
        /// Add a permission
        /// </summary>
        /// <param name="permission">Permission object/param>
        public Task Add(Permission permission);

        /// <summary>
        /// Update a permission
        /// </summary>
        /// <param name="permission">Permission object/param>
        public Task Update(Permission permission);

        /// <summary>
        /// Add or update many permissions
        /// </summary>
        /// <param name="permissions">Permissions object list/param>
        public Task AddOrUpdateRange(List<Permission> permissions);

        /// <summary>
        /// Delete a permission
        /// </summary>
        /// <param name="id">Permission id/param>
        public void DeleteById(long id);

        /// <summary>
        /// Get permissions by profile id
        /// </summary>
        /// <param name="profileId">Profile id/param>
        /// <returns>List of permissions</returns>
        public List<Permission> GetPermissionsByProfileId(long profileId);

        /// <summary>
        /// Performs permissions
        /// </summary>
        /// <returns>Excel model of permissions</returns>
        public Excel GetExcel();

        /// <summary>
        /// Get permission excel model
        /// </summary>
        /// <returns>Permission excel model</returns>
        public Excel GetExcelModel();

        /// <summary>
        /// Register permissions in database
        /// </summary>
        /// <param name="file">Permission excel file</param>
        /// <exception cref="Exceptions.DomainException">Validation rules</exception>
        public Task RegisterByExcel(IFormFile file);
    }
}