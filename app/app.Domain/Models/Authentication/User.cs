using app.Domain.Models.Base;
using System.Collections;

namespace app.Domain.Models.Authentication
{
    public class User : BaseModel
    {
        public User() { }

        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual string NewPassword { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual string? Token { get; set; }
        public string? SessionId { get; set; }
        public long ProfileId { get; set; }
        public virtual IEnumerable Permissions { get; set; }
        public Profile Profile { get; set; }
    }
}