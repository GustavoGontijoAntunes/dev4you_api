using app.Domain.Models.Authentication;
using app.Domain.Models.Base;

namespace app.Domain.Models
{
    public class Profile : BaseModel
    {
        public Profile() { }

        public string Name { get; set; }
        public List<Permission> Permissions { get; set; }
        public virtual List<long> PermissionsIds { get; set; }
        public List<User> Users { get; set; }
    }
}