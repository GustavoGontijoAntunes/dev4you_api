using app.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.RepositoryAdapter.Mapppings
{
    public class PermissionMap : EntityMappingBase<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permission");

            builder.Property(x => x.Name);
            builder.Property(x => x.Description);

            builder.HasMany(x => x.Profiles)
                .WithMany(y => y.Permissions)
                .UsingEntity<ProfilePermission>();
        }
    }
}