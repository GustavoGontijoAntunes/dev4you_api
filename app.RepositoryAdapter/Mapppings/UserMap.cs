using app.Domain.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.RepositoryAdapter.Mapppings
{
    public class UserMap : EntityMappingBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user");

            builder.Property(x => x.Name);
            builder.Property(x => x.Login);
            builder.Property(x => x.Password);

            builder.Property(x => x.SessionId);

            builder.Ignore(x => x.NewPassword);
            builder.Ignore(x => x.Permissions);
            builder.Ignore(x => x.Token);

            builder.HasOne(x => x.Profile)
                .WithMany(y => y.Users).HasForeignKey(z => z.ProfileId);
        }
    }
}