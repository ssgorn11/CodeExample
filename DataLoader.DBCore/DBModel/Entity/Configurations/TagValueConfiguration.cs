using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта TagValueEntity
    /// </summary>
    internal class TagValueConfiguration : IEntityTypeConfiguration<TagValueEntity>
    {
        public void Configure(EntityTypeBuilder<TagValueEntity> builder)
        {
            builder.ToTable("TagValue").HasKey(d => d.Id);
            builder.HasIndex(p => p.IdTag);
            builder.HasIndex(p => p.DatePHD);
        }
    }
}
