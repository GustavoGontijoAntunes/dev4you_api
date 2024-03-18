using app.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace app.RepositoryAdapter.Mapppings
{
    public class PermissionProfileMap : EntityMappingBase<ProfilePermission>
    {
        public override void Configure(EntityTypeBuilder<ProfilePermission> builder)
        {
            builder.ToTable("profilePermission");
        }
    }
}