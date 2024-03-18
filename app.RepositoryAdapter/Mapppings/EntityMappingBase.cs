using app.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.RepositoryAdapter.Mapppings
{
    public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
