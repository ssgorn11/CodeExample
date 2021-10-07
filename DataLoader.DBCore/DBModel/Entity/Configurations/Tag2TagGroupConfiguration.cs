using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта Tag2TagGroupEntity
    /// </summary>
    internal class Tag2TagGroupConfiguration : IEntityTypeConfiguration<Tag2TagGroupEntity>
    {
        public void Configure(EntityTypeBuilder<Tag2TagGroupEntity> builder)
        {
            builder.ToTable("Tag2TagGroup").HasKey(d => d.Id);
            builder.HasIndex(x => x.IdTag);
            builder.HasIndex(x => x.IdTagGroup);
        }
    }
}
