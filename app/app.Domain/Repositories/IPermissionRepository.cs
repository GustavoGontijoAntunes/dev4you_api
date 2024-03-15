using app.Domain.Models;

namespace app.Domain.Repositories
{
    public interface IPermissionRepository : IRepository
    {
        public IEnumerable<Permission> GetAll();
        public Permission GetByName(string name);
        public Permission GetById(long id);
        public Task Add(Permission permission);
        public Task Update(Permission permission);
        public Task AddOrUpdateRange(List<Permission> permissions);
        public void DeleteById(long id);
        public List<Permission> GetPermissionsByProfileId(long profileId);
        public Task AddOrUpdatePermissionsToProfile(List<ProfilePermission> profilePermissions);
        public void DeleteProfilePermissionsByProfileId(long profileId);
        public bool IsUsedInSomeProfile(long id);
    }
}