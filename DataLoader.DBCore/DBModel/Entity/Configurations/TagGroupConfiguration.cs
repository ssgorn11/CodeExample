using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта TagGroupEntity
    /// </summary>
    internal class TagGroupConfiguration : IEntityTypeConfiguration<TagGroupEntity>
    {
        public void Configure(EntityTypeBuilder<TagGroupEntity> builder)
        {
            builder.ToTable("TagGroup").HasKey(d => d.Id);
        }
    }
}
