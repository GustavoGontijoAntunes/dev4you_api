using app.Domain.Models.Base;

namespace app.Domain.Models
{
    public class Permission : BaseModel
    {
        public Permission() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}