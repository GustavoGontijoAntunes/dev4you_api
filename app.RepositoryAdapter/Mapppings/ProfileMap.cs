using app.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.RepositoryAdapter.Mapppings
{
    public class ProfileMap : EntityMappingBase<Profile>
    {
        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("profile");

            builder.Property(x => x.Name);

            builder.Ignore(x => x.PermissionsIds);

            builder.HasMany(x => x.Permissions)
                .WithMany(y => y.Profiles)
                .UsingEntity<ProfilePermission>();
        }
    }
}